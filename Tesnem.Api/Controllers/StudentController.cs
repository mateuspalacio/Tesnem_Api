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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddStudent([FromBody] StudentRequest s)
        {
            var resp = await _service.AddStudent(s);
            return Ok(resp);
        }
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid id, [FromBody] StudentRequest s)
        {
            var resp = await _service.UpdateStudent(id, s);
            return Ok(resp);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
        {
            await _service.DeleteStudent(id);
            return NoContent();
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<StudentResponse>> GetStudent([FromRoute] Guid id)
        {
            var resp = await _service.GetStudentById(id);
            return Ok(resp);
        }

        [HttpGet]
        [Route("get/all")]
        public async Task<ActionResult<IEnumerable<StudentResponse>>> GetAllStudents()
        {
            var resp = await _service.GetAllStudents();
            return Ok(resp);
        }
        [HttpGet]
        [Route("get/all/course/{courseId}")]
        public async Task<ActionResult<IEnumerable<StudentResponse>>> GetStudentsByCourse([FromRoute] Guid courseId)
        {
            var resp = await _service.GetAllStudentsByCourse(courseId);
            return Ok(resp);
        }
        [HttpGet]
        [Route("get/all/class/{classId}")]
        public async Task<ActionResult<IEnumerable<StudentResponse>>> GetStudentsByClass([FromRoute] Guid classId)
        {
            var resp = await _service.GetAllStudentsByClass(classId);
            return Ok(resp);
        }
        [HttpDelete]
        [Route("delete/list")]
        public async Task<ActionResult<IEnumerable<DeleteListResponse>>> DeleteStudents([FromBody] DeleteListRequest list)
        {
            var resp = await _service.DeleteMultipleStudents(list.DeleteList);
            return Ok(resp);
        }
    }
}
