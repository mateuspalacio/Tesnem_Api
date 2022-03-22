using Microsoft.AspNetCore.Mvc;
using Tesnem.Api.Domain.DTO;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Services;

namespace Tesnem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddStudent([FromBody] StudentDto s)
        {
            var resp = await _service.AddStudent(s);
            return Ok(resp);
        }
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] string id, [FromBody] StudentDto s)
        {
            var resp = await _service.UpdateStudent(id, s);
            return Ok(resp);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] string id)
        {
            await _service.DeleteStudent(id);
            return NoContent();
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] string id)
        {
            var resp = await _service.GetStudentById(id);
            return Ok(resp);
        }
    }
}
