using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IGuestService _guestService;
        private readonly IRoomService _roomService;

        public DashboardWidgetController(IStaffService staffService, IBookingService bookingService, IGuestService guestService, IRoomService roomService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _guestService = guestService;
            _roomService = roomService;
        }

        [HttpGet("StaffCount")]
        public IActionResult GetStaffCount()
        {
            var staffCount=_staffService.TGetStaffCount();
            return Ok(staffCount);
        }

        [HttpGet("BookingCount")]
        public IActionResult GetBookingCount()
        {
            var bookingService = _bookingService.TGetBookingCount();
            return Ok(bookingService);
        }

        [HttpGet("GuestCount")]
        public IActionResult GetGuestCount()
        {
            var guestService = _guestService.TGetGuestCount();
            return Ok(guestService);
        }

        [HttpGet("RoomCount")]
        public IActionResult GetRoomCount()
        {
            var roomService = _roomService.TGetRoomCount();
            return Ok(roomService);
        }
    }
}
