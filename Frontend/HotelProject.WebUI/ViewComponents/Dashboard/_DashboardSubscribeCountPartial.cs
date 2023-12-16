using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {


        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Rapid Api sitesinden Instagram Profile Api den alındı
            var client = new HttpClient();

            ///INSTAGRAM/////////////////
            ResultInstagramFollowersDto resultInstagramFollowersDtos = new ResultInstagramFollowersDto();//gelen veriye göre oluşturduğum dto ile liste oluşturdum
            var requestInstagram = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/emin_yasircrt"),
                Headers =
    {
        { "X-RapidAPI-Key", "73feb3c136msh68e8bb609ac11b7p19401ajsnf1d91b7a5f70" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(requestInstagram))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                resultInstagramFollowersDtos = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);//gelen veri alınıp view a gönderildi.
                ViewBag.followingInsta = resultInstagramFollowersDtos.following;
                ViewBag.followersInsta = resultInstagramFollowersDtos.followers;

            }

            /////TWİTTER/////////////////////////
            ResultTwitterFollowersDto resultTwitterFollowersDto=new ResultTwitterFollowersDto();
            var requestTwitter = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter154.p.rapidapi.com/user/details?username=corut_yasir58&user_id=96479162"),
                Headers =
    {
        { "X-RapidAPI-Key", "73feb3c136msh68e8bb609ac11b7p19401ajsnf1d91b7a5f70" },
        { "X-RapidAPI-Host", "twitter154.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(requestTwitter))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                resultTwitterFollowersDto = JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(body);//gelen veri alınıp view a gönderildi.
                ViewBag.followingTwit = resultTwitterFollowersDto.following_count;
                ViewBag.followersTwit = resultTwitterFollowersDto.follower_count;
            }


            ///////LİNKEDİN///////////////////
            ResultLinkedinFollowersDto resultLinkedinFollowersDto=new ResultLinkedinFollowersDto();
            var requestLinked = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Femin-yasir-corut-b46a051b0%2F&include_skills=false"),
                Headers =
    {
        { "X-RapidAPI-Key", "73feb3c136msh68e8bb609ac11b7p19401ajsnf1d91b7a5f70" },
        { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(requestLinked))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                resultLinkedinFollowersDto=JsonConvert.DeserializeObject<ResultLinkedinFollowersDto>(body);
                ViewBag.followingLinked = resultLinkedinFollowersDto.data.followers_count;
            }




            return View();

        }
    }
}
