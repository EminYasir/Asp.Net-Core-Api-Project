using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AboutAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//istemci oluşturduk
            var responsMessage = await client.GetAsync("http://localhost:5296/api/About");//personel adresine istekte bulunuyoruz
            if (responsMessage.IsSuccessStatusCode)//kontrol
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();//gelen veri json türünde
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);//json ı tabloda kullanabileceiğim formata çeviriyorum
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesssage = await client.GetAsync($"http://localhost:5296/api/About/{id}");//tek veri olarak gelicek id ye göre istedik
            if (responseMesssage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesssage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);//sadece bir veri olarak gelicek o yüzden liste olarak çekmedik
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMesssage = await client.PutAsync("http://localhost:5296/api/About/", stringcontent);
            if (responseMesssage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
