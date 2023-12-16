using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace HotelProject.WebUI.Controllers
{
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public AdminRoleController(RoleManager<AppRole> roleManager)
        {
            this._roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult RoleAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleAdd(AddRoleViewModel addRoleViewModel)
        {
            AppRole appRole = new AppRole()
            {
                Name = addRoleViewModel.RoleName
            };
            var result = await _roleManager.CreateAsync(appRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        public async Task<IActionResult> RoleDelete(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult RoleUpdate(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleViewModel updateRoleView = new UpdateRoleViewModel()
            {
                RoleName = values.Name,
                RoleID = values.Id
            };
            return View(updateRoleView);
        }
        [HttpPost]
        public async Task<IActionResult> RoleUpdate(UpdateRoleViewModel updateRoleView)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == updateRoleView.RoleID);
            values.Name = updateRoleView.RoleName;
            await _roleManager.UpdateAsync(values);
            return RedirectToAction("Index");
        }
    }
}
