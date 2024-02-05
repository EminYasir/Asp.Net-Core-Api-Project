using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();//istemci oluşturduk
            var responsMessage = await client.GetAsync("http://localhost:5296/api/Contact");

            var client2 = _httpClientFactory.CreateClient();//istemci oluşturduk
            var responsMessage2 = await client2.GetAsync("http://localhost:5296/api/Contact/GetContactCount");

            var client3 = _httpClientFactory.CreateClient();//istemci oluşturduk
            var responsMessage3 = await client3.GetAsync("http://localhost:5296/api/SendMessage/SendMessageCount");

            if (responsMessage.IsSuccessStatusCode)//kontrol
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();//gelen veri json türünde
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);//json ı tabloda kullanabileceiğim formata çeviriyorum

                var jsondata2=await responsMessage2.Content.ReadAsStringAsync();
                ViewBag.ContactCount = jsondata2;

                var jsondata3 = await responsMessage3.Content.ReadAsStringAsync();
                ViewBag.SendMessageCount = jsondata3;


                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();//istemci oluşturduk
            var responsMessage = await client.GetAsync("http://localhost:5296/api/SendMessage");//personel adresine istekte bulunuyoruz

            var client2 = _httpClientFactory.CreateClient();//istemci oluşturduk
            var responsMessage2 = await client2.GetAsync("http://localhost:5296/api/Contact/GetContactCount");

            var client3 = _httpClientFactory.CreateClient();//istemci oluşturduk
            var responsMessage3 = await client3.GetAsync("http://localhost:5296/api/SendMessage/SendMessageCount");

            if (responsMessage.IsSuccessStatusCode)//kontrol
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();//gelen veri json türünde
                var values = JsonConvert.DeserializeObject<List<ResultSendMessageDto>>(jsonData);//json ı tabloda kullanabileceiğim formata çeviriyorum

                var jsondata2 = await responsMessage2.Content.ReadAsStringAsync();
                ViewBag.ContactCount = jsondata2;

                var jsondata3 = await responsMessage3.Content.ReadAsStringAsync();
                ViewBag.SendMessageCount = jsondata3;
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto model)
        {
            model.SenderMail= "admin@gmail.com";
            model.SenderName= "admin";
            model.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);//jsona çeviriyoz,
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5296/api/SendMessage", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();
        }


        public PartialViewResult SideBarAdminContactPartial()
        {
            return PartialView();   
        }
        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }

        

        [HttpGet]
        public async Task<IActionResult> MessageDetailsBySendBox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesssage = await client.GetAsync($"http://localhost:5296/api/SendMessage/{id}");//tek veri olarak gelicek id ye göre istedik
            if (responseMesssage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesssage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);//sadece bir veri olarak gelicek o yüzden liste olarak çekmedik
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MessageDetailsByInBox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesssage = await client.GetAsync($"http://localhost:5296/api/Contact/{id}");//tek veri olarak gelicek id ye göre istedik
            if (responseMesssage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesssage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);//sadece bir veri olarak gelicek o yüzden liste olarak çekmedik
                return View(values);
            }
            return View();
        }
    }
}
