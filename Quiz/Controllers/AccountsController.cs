using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quiz.Data.Repositories.Interfaces;
using Quiz.Helpers;
using Quiz.Models.Entities;
using Quiz.Web.ViewModels;

namespace Quiz.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public AccountsController
            (UserManager<User> userManager, SignInManager<User> signInManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }

        // [Authorize(Roles = Constants.AdminRole)]
        public async Task<IActionResult> Users()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();

            return View(users);
        }

        public IActionResult LogIn()
        {
            return View(new LogInUserVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LogInUserVM form)
        {
            if (!ModelState.IsValid)
                return View(form);

            User? user = await _userManager.FindByEmailAsync(form.Email);

            if (user == null)
            {
                form.ErrorMessage = "Please enter a valid email or password";

                return View(form);
            }

            bool isPasswordValid = await _userManager.CheckPasswordAsync(user, form.Password);

            if (isPasswordValid)
            {
                //var isUserSignedIn = _signInManager.SignInAsync(user, false);
                var isUserSignedIn = await _signInManager.PasswordSignInAsync(user, form.Password, false, false);

                if (isUserSignedIn.Succeeded)
                    return RedirectToAction("Questions", "Users");
            }

            form.ErrorMessage = "Please enter a valid email or password";

            return View(form);
        }

        public IActionResult Register()
        {
            return View(new RegisterUserVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserVM form)
        {
            if (!ModelState.IsValid)
                return View(form);

            User user = await _userManager.FindByEmailAsync(form.Email);

            if (user != null)
            {
                form.ErrorMessage = "This email is used by another user";
                return View(form);
            }

            User newUser = new User()
            {
                FullName = form.FullName,
                UserName = form.Email,
                Email = form.Email,
                EmailConfirmed = true
            };

            var passwordHash = _userManager.PasswordHasher.HashPassword(newUser, form.Password);

            newUser.PasswordHash = passwordHash;

            var isUserCreated = await _userManager.CreateAsync(newUser);

            // Add user to Role
            if (isUserCreated.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, Constants.UserRole);

                // navigate to Log In
                return View(nameof(Constants.CompleteRegister));
            }
            // The Password is WEAK or taken
            else
            {
                List<IdentityError> errors = isUserCreated.Errors.ToList();

                string errorsAsstring = string.Join(",", errors.Select(e => e.Description));
                form.ErrorMessage = errorsAsstring;

                return View(form);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }
    }
}
