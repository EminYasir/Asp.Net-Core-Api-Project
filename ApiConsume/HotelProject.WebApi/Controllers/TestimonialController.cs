using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonailservice;

        public TestimonialController(ITestimonialService testimonail)
        {
            _testimonailservice = testimonail;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonailservice.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimoniall(int id)
        {
            var Testimonial = _testimonailservice.TGetByID(id);
            return Ok(Testimonial);
        }

        [HttpPost]
        public IActionResult AddTestimonial(Testimonial Testimonial)
        {
            _testimonailservice.TInsert(Testimonial);
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult TestimonialDelete(int id)
        {
            var value = _testimonailservice.TGetByID(id);
            _testimonailservice.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial Testimonial)
        {
            _testimonailservice.TUpdate(Testimonial);
            return Ok();
        }
    }
}
