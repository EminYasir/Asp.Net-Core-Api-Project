using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        public IActionResult GuestList()
        {
            var values = _guestService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetGuest(int id)
        {
            var Service = _guestService.TGetByID(id);
            return Ok(Service);
        }
        [HttpPut]
        public IActionResult UpdateGuest(Guest guest)
        {
            _guestService.TUpdate(guest);
            return Ok();
        }

        [HttpPost]
        public IActionResult AddGuest(Guest guest)
        {
            _guestService.TInsert(guest);
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult GuestDelete(int id)
        {
            var value = _guestService.TGetByID(id);
            _guestService.TDelete(value);
            return Ok();
        }
    }
}
