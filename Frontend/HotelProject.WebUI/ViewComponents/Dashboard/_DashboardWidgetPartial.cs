using HotelProject.WebUI.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();//istemci oluşturduk
            var responsMessage = await client.GetAsync("http://localhost:5296/api/DashboardWidget/StaffCount");
            var jsonData = await responsMessage.Content.ReadAsStringAsync();//gelen veri json türünde
 
            ViewBag.staffCount = jsonData;
            var client2 = _httpClientFactory.CreateClient();//istemci oluşturduk
            var responsMessage2 = await client2.GetAsync("http://localhost:5296/api/DashboardWidget/BookingCount");
            var jsonData2 = await responsMessage2.Content.ReadAsStringAsync();//gelen veri json türünde
 
            ViewBag.bookingCount = jsonData2;
            var client3 = _httpClientFactory.CreateClient();//istemci oluşturduk
            var responsMessage3 = await client3.GetAsync("http://localhost:5296/api/DashboardWidget/GuestCount");
            var jsonData3 = await responsMessage3.Content.ReadAsStringAsync();//gelen veri json türünde
 
            ViewBag.guestCount = jsonData3;
            var client4 = _httpClientFactory.CreateClient();//istemci oluşturduk
            var responsMessage4 = await client4.GetAsync("http://localhost:5296/api/DashboardWidget/RoomCount");
            var jsonData4 = await responsMessage4.Content.ReadAsStringAsync();//gelen veri json türünde
            ViewBag.roomCount = jsonData4;



            return View();
        }
    }
}
