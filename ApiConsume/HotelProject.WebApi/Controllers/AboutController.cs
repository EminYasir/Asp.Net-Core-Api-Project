using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var rooms = _aboutService.TGetList();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var room = _aboutService.TGetByID(id);
            return Ok(room);
        }

        [HttpPost]
        public IActionResult AddAbout(About about)
        {
            _aboutService.TInsert(about);
            return Ok();

        }
        [HttpDelete]
        public IActionResult AboutDelete(int id)
        {
            var about = _aboutService.TGetByID(id);
            _aboutService.TDelete(about);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateAbout(About about)
        {
            _aboutService.TUpdate(about);
            return Ok();
        }
    }
}
