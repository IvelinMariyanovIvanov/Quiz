using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quiz.Data.Repositories.Interfaces;
using Quiz.Helpers;
using Quiz.Models.Entities;
using Quiz.Web.ViewModels;
using System.Data.Entity;
using X.PagedList;

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

        [Authorize(Roles = Constants.AdminRole)]
        public IActionResult Users()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = Constants.AdminRole)]
        public async Task<IActionResult> GetAllUsersAPI()
        {
            List<User> users = await _unitOfWork.UserRepository.GetAllAsync(includeTables: "AnswerUsers");

            // do not show user with no Achievements
            users = users.Where(u => u.AnswerUsers.Count() > 0).ToList();

            return Json(new { data = users});
        }

        [Authorize(Roles = Constants.AdminRole)]
        public async Task<IActionResult> UserAchievements(string userId, string sortOrder, int page = 1)
        {
            if (page == 0 && page < 1)
                page = 1;

            ViewData["QuoteSortParm"] = String.IsNullOrEmpty(sortOrder) ? "quote_desc" : "";
            ViewData["IsCorrectSortParm"] = sortOrder == "isCorrect" ? "isCorrect_desc" : "isCorrect";

            var pageSize = Constants.DefaultPageSize;

            IQueryable<UserAnswers> userAnswers = _unitOfWork.AnswerUserRepository
                .GetAllWithLinqAsyncAsIQueryable
                  (u => u.UserId == userId,
                  includeTables: "User,Answer,Answer.Quote,Answer.Question.CorrectAuthor");
                    //.ToPagedList(page ?? 1, pageSize);
                    //.ToPagedListAsync(page, pageSize);

            if (userAnswers.Count() == 0)
            {
                TempData["error"] = $"There are no Achievements for that user";
                return RedirectToAction(nameof(Users));
            }

            switch (sortOrder)
            {
                case "quote_desc":
                    userAnswers = userAnswers.OrderByDescending(a => a.Answer.Quote.Text);
                    break;
                case "isCorrect":
                    userAnswers = userAnswers.OrderBy(a => a.Answer.IsCorrect);
                    break;
                case "isCorrect_desc":
                    userAnswers = userAnswers.OrderByDescending(a => a.Answer.IsCorrect);
                    break;
                default:
                    userAnswers = userAnswers.OrderBy(a => a.Answer.Quote.Text);
                    break;
            }

            //return View(userAnswers);
            return View(await userAnswers.ToPagedListAsync(page, pageSize));
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
                    return RedirectToAction(nameof(Constants.Questions), nameof(Constants.Questions));
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
