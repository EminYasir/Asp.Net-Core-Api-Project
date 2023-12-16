using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileImageController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile formFile)
        {
            var filename=Guid.NewGuid()+Path.GetExtension(formFile.FileName);//her yükleyenin farklı path ile yüklemesi için
            var path = Path.Combine(Directory.GetCurrentDirectory(), "images/" + filename);
            var stream = new FileStream(path, FileMode.Create);
            await formFile.CopyToAsync(stream);
            return Created("", formFile);

        }
    }
}
