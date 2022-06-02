using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tesnem.Api.Domain.DTO;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.DTO.ResponseDTO;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Services;

namespace Tesnem.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
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
        public async Task<IActionResult> GetCourseById([FromRoute] Guid id)
        {
            var resp = await _service.GetCourseById(id);
            return Ok(resp);
        }
        [HttpGet]
        [Route("get/Major/{id}")]
        public async Task<IActionResult> GetCourseByProgramId([FromRoute] Guid id)
        {
            var resp = await _service.GetCourseByProgramId(id);
            return Ok(resp);
        }
        [HttpGet]
        [Route("get/all")]
        public async Task<ActionResult<IEnumerable<CourseResponse>>> GetAllCourses()
        {
            var resp = await _service.GetAllCourses();
            return Ok(resp);
        }
        [HttpDelete]
        [Route("delete/list")]
        public async Task<ActionResult<IEnumerable<DeleteListResponse>>> DeleteCourses([FromBody] DeleteListRequest list)
        {
            var resp = await _service.DeleteMultipleCourses(list.DeleteList);
            return Ok(resp);
        }
    }
}
