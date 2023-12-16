using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardLast4Staff : ControllerBase
    {
        private readonly IStaffService _staffService;

        public DashboardLast4Staff(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet("Last4StaffList")]
        public IActionResult Last4Staff()
        {
            var value = _staffService.TGetLast4StaffList();
            return Ok(value);
        }
    }
}
