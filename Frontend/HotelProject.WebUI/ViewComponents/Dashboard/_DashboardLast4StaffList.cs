﻿using HotelProject.WebUI.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardLast4StaffList:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DashboardLast4StaffList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();//istemci oluşturduk
            var responsMessage = await client.GetAsync("http://localhost:5296/api/Staff/Last4StaffList");
            if (responsMessage.IsSuccessStatusCode)//kontrol
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();//gelen veri json türünde
                var values = JsonConvert.DeserializeObject<List<ResultStaffDto>>(jsonData);//json ı tabloda kullanabileceiğim formata çeviriyorum
                return View(values);
            }
            return View();
        }

    }
}
