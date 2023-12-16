using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _subscribeService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetSubscribel(int id)
        {
            var Subscribe = _subscribeService.TGetByID(id);
            return Ok(Subscribe);
        }

        [HttpPost]
        public IActionResult AddSubscribe(Subscribe Subscribe)
        {
            _subscribeService.TInsert(Subscribe);
            return Ok();

        }
        [HttpDelete]
        public IActionResult SubscribeDelete(int id)
        {
            var value = _subscribeService.TGetByID(id);
            _subscribeService.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe Subscribe)
        {
            _subscribeService.TUpdate(Subscribe);
            return Ok();
        }
    }
}
