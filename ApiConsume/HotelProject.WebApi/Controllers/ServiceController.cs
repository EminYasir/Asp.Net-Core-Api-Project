using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _serviceService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetServicel(int id)
        {
            var Service = _serviceService.TGetByID(id);
            return Ok(Service);
        }

        [HttpPost]
        public IActionResult AddService(Service Service)
        {
            _serviceService.TInsert(Service);
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult ServiceDelete(int id)
        {
            var value = _serviceService.TGetByID(id);
            _serviceService.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateService(Service Service)
        {
            _serviceService.TUpdate(Service);
            return Ok();
        }
    }
}
