using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tesnem.Api.Domain.DTO;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.DTO.ResponseDTO;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Services;

namespace Tesnem.Api.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _service;
        public ProfessorController(IProfessorService service)
            {
                _service = service;
            }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddProfessor([FromBody] ProfessorRequest p)
        {
            var resp = await _service.AddProfessor(p);
            return Ok(resp);
        }
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateProfessor([FromRoute] Guid id, [FromBody] ProfessorRequest p)
        {
            var resp = await _service.UpdateProfessor(id, p);
            return Ok(resp);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteProfessor([FromRoute] Guid id)
        {
            await _service.DeleteProfessor(id);
            return NoContent();
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetProfessor([FromRoute] Guid id)
        {
            var resp = await _service.GetProfessorById(id);
            return Ok(resp);
        }

        [HttpGet]
        [Route("get/all")]
        public async Task<ActionResult<IEnumerable<ProfessorResponse>>> GetAllProfessors()
        {
            var resp = await _service.GetAllProfessors();
            return Ok(resp);
        }
        [HttpGet]
        [Route("get/all/course/{courseId}")]
        public async Task<IActionResult> GetProfessorsByCourse([FromRoute] Guid courseId)
        {
            var resp = await _service.GetAllProfessorsByCourse(courseId);
            return Ok(resp);
        }
        [HttpDelete]
        [Route("delete/list")]
        public async Task<ActionResult<IEnumerable<DeleteListResponse>>> DeleteProfessors([FromBody] DeleteListRequest list)
        {
            var resp = await _service.DeleteMultipleProfessors(list.DeleteList);
            return Ok(resp);
        }
    }
}
