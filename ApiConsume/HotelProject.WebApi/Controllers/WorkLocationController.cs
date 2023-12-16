using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationService _workLocationService;

        public WorkLocationController(IWorkLocationService workLocationService)
        {
            _workLocationService = workLocationService;
        }

        [HttpGet]
        public IActionResult WorkLocationList()
        {
            var values = _workLocationService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetWorkLocation(int id)
        {
            var Service = _workLocationService.TGetByID(id);
            return Ok(Service);
        }
        [HttpPut]
        public IActionResult UpdateWorkLocation(WorkLocation guest)
        {
            _workLocationService.TUpdate(guest);
            return Ok();
        }

        [HttpPost]
        public IActionResult AddWorkLocation(WorkLocation guest)
        {
            _workLocationService.TInsert(guest);
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult WorkLocationDelete(int id)
        {
            var value = _workLocationService.TGetByID(id);
            _workLocationService.TDelete(value);
            return Ok();
        }
    }
}
