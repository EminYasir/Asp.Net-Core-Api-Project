using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _AboutUsPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();//istemci oluşturduk
            var responsMessage = await client.GetAsync("http://localhost:5296/api/About");//HAkkımızda adresine istekte bulunuyoruz
            if (responsMessage.IsSuccessStatusCode)//kontrol
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();//gelen veri json türünde
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);//json ı tabloda kullanabileceiğim formata çeviriyorum
                return View(values);
            }
            return View();
        }
    }
}
