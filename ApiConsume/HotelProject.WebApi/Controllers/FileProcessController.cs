using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileProcessController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile formFile)
        {
            var filename = Guid.NewGuid() + Path.GetExtension(formFile.FileName);//her yükleyenin farklı path ile yüklemesi için
            var path = Path.Combine(Directory.GetCurrentDirectory(), "files/" + filename);
            var stream = new FileStream(path, FileMode.Create);
            await formFile.CopyToAsync(stream);
            return Created("", formFile);

        }
    }
}
