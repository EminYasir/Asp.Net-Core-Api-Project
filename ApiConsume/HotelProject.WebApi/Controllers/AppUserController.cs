using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
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
    }
}
