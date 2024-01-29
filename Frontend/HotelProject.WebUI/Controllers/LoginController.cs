using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.LoginDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]//kullanıcı tarafından açılmasına izin verme
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;


        public LoginController(SignInManager<AppUser> signInManager, IHttpClientFactory httpClientFactory)
        {
            _signInManager = signInManager;
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDto loginUserDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(loginUserDto);//jsona çeviriyoz,
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage =  await client.PostAsync("http://localhost:5296/api/AppUser/LLogin", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                await _signInManager.PasswordSignInAsync(loginUserDto.UserName, loginUserDto.Password, true, true);
                return RedirectToAction("Index","Dashboard");
            }
            return View();
        }


        public IActionResult SignOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

    }
}
