using Microsoft.AspNetCore.Mvc;
using Tesnem.Api.Domain.DTO;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Services;

namespace Tesnem.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;
        public CourseController(ICourseService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddCourse([FromBody] CourseRequest s)
        {
            var resp = await _service.AddCourse(s);
            return Ok(resp);
        }
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateCourse([FromRoute] Guid id, [FromBody] CourseRequest s)
        {
            var resp = await _service.UpdateCourse(id, s);
            return Ok(resp);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] Guid id)
        {
            await _service.DeleteCourse(id);
            return NoContent();
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetCourse([FromRoute] Guid id)
        {
            var resp = await _service.GetCourseById(id);
            return Ok(resp);
        }
    }
}
