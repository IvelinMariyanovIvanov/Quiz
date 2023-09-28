using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiz.Data.Migrations;
using Quiz.Data.Repositories.Interfaces;
using Quiz.Helpers;
using Quiz.Models.Entities;
using Quiz.Web.ViewModels;

namespace Quiz.Web.Controllers
{
    [Authorize(Roles = Constants.AdminRole)]
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        public IActionResult UsersGrid()
        {
            return View(nameof(Constants.UsersGrid));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAPI()
        {
            List<User> users = await _unitOfWork.UserRepository.GetAllAsync();

            return Json(new { data = users });
        }

        public IActionResult CreateUser()
        {
            CreateUserVM viewModel = new CreateUserVM();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser(CreateUserVM form)
        {
            if (!ModelState.IsValid)
                return View(form);

            var user = await _unitOfWork.UserRepository.GetEntityAsync(u => u.Email == form.Email);

            if (user != null)
            {
                TempData["error"] = $"There is a user with email {form.Email}";
                return View(form);
            }

            try
            {
                // map from view model to entity
                User entity = _mapper.Map<User>(form);
  
                await _unitOfWork.UserRepository.AddAsync(entity);
                await _unitOfWork.SaveAsync();

                TempData["success"] = $"You Successfully created a user with name {form.FullName}";

                return RedirectToAction(nameof(UsersGrid));
            }
            catch
            {
                TempData["error"] = "Can not create the user";

                return View(form);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserAPI(string id)
        {
            User user = await _unitOfWork.UserRepository.GetEntityAsync(u => u.Id == id);

            if (user == null)
                return Json(new { success = false, message = "Not found" });

            try
            {
                _unitOfWork.UserRepository.Delete(user);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                return Json(new { success = false, message = $"Can not delete the user with na,e {user.FullName}" });
            }

            return Json(new { success = true, message = $"The user with name {user.FullName} is deleted" });
        }

        [HttpPost]
        public async Task <IActionResult> LockOrUnlockUserAPI([FromBody] string userId)
        {
            if (userId == null)
                return Json(new { success = false, message = "The user does not exists" });

            User user = await _unitOfWork.UserRepository.GetEntityAsync(u => u.Id == userId);

            if (user == null)
                return Json(new { success = false, message = "The user does not exists" });

            // if the user is locked, unlocked him
            if (user.LockoutEnd != null && user.LockoutEnd > DateTime.UtcNow)
                user.LockoutEnd = DateTime.UtcNow;
            else
                user.LockoutEnd = DateTime.UtcNow.AddMinutes(2);

            await _unitOfWork.SaveAsync();

            return Json(new { success = true, message = "The user is locked or unlocked" });

        }
    }
}
