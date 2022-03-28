using Microsoft.AspNetCore.Mvc;
using Tesnem.Api.Domain.DTO;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Services;

namespace Tesnem.Api.Controllers
{
    [Route("[controller]/")]
    [ApiController]
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
    }
}
