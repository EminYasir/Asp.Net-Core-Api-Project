using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.LoginDto;
using HotelProject.DtoLayer.Dtos.RegisterDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly UserManager<AppUser> _userManager;

        public AppUserController(IAppUserService appUserService,UserManager<AppUser> userManager)
        {
            _appUserService = appUserService;
            _userManager = userManager;
        }

        [HttpPost("UserLogin")]
        public IActionResult Login()
        {
            var result = _appUserService.TGetList();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult UserListWithWorkLocation()
        {
            var values = _appUserService.TUserListWithWorkLocation();//bu fonksiyon user sınıf ile worklocation sınıfının nested şekilde birleşimini geitiri.
            //var values = _appUserService.TGetList();               //Eğer ben user ve worklocation içindki verileri nested yapı olmadan getirmek istiyosam
            return Ok(values);                                       // AppUserWorkLocation Sınıfında yaptığım Include fonksiyonunu kullnamalıyım.
        }

        [HttpGet("AppUserList")]
        public IActionResult AppUserList()
        {
            var values = _appUserService.TGetList();
            return Ok(values);
        }
        [HttpPost("LLogin")]
        public IActionResult Loginn(LoginDto loginDto)
        {
            var vale = _appUserService.TGetList().FirstOrDefault(x => x.UserName == loginDto.UserName);
            if (vale != null)
            {
                if (vale.RealPassword == loginDto.Password)
                {
                    return Ok("Başarılı");

                }
                return BadRequest("Geçersiz şifre.");
            }
            return BadRequest("Geçersiz şifre.");

        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var appUser = new AppUser()
            {
                Name = registerDto.Name,
                Email = registerDto.Mail,
                Surname = registerDto.Surname,
                UserName = registerDto.UserName,
                City = registerDto.City,
                ImageUrl = registerDto.ImageUrl,
                Gender = registerDto.Gender,
                Country = registerDto.Country,
                RealPassword = registerDto.Password,
                WorkLocationID = 1,
                WorkLocationDepartman = "İstanbul",
            };

            var result = await _userManager.CreateAsync(appUser, registerDto.Password);

            if (result.Succeeded)
            {
                appUser.PasswordHash = _userManager.PasswordHasher.HashPassword(appUser, registerDto.Password);
                await _appUserService.TInsertAsync(appUser);
                return Ok("Başarılı");
            }
            else
            {
                // If user creation fails, return error details
                return BadRequest(result.Errors);
            }

        }
    }
}
