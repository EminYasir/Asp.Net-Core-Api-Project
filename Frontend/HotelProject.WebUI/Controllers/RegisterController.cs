using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.Dtos.RegisterDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(UserManager<AppUser> userManager, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto createNewUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createNewUserDto);//jsona çeviriyoz,
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5296/api/AppUser/Register", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
