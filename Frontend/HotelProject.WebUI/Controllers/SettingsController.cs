using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Setting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel viewModel = new UserEditViewModel();
            viewModel.Name = user.Name;
            viewModel.Email = user.Email;
            viewModel.Surname = user.Surname;
            viewModel.Username = user.UserName;
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (editViewModel.Password == editViewModel.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Surname = editViewModel.Surname;
                user.Email = editViewModel.Email;
                user.Name = editViewModel.Name;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, editViewModel.Password);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return RedirectToAction("Index");
        }
    }
}
