using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tesnem.Api.Domain.DTO;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Services;


namespace Tesnem.Api.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _service;
        public EnrollmentController(IEnrollmentService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddEnrollment([FromBody] EnrollmentRequest s)
        {
            var resp = await _service.AddEnrollment(s);
            return Ok(resp);
        }
        [HttpPost]
        [Route("addClasses/{enrollmentNumber}")]
        public async Task<IActionResult> AddClasses([FromRoute] string enrollmentNumber,[FromBody] AddClassesRequest s)
        {
            var resp = await _service.AddClasses(enrollmentNumber,s);
            return Ok(resp);
        }
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateEnrollment([FromRoute] Guid id, [FromBody] EnrollmentRequest s)
        {
            var resp = await _service.UpdateEnrollment(id, s);
            return Ok(resp);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteEnrollment([FromRoute] Guid id)
        {
            await _service.DeleteEnrollment(id);
            return NoContent();
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetEnrollment([FromRoute] Guid id)
        {
            var resp = await _service.GetEnrollmentById(id);
            return Ok(resp);
        }

    }
}
