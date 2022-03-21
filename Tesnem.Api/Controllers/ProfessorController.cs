using Microsoft.AspNetCore.Mvc;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Services;

namespace Tesnem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : Controller
    {
        private readonly IProfessorService _service;
        public ProfessorController(IProfessorService service)
            {
                _service = service;
            }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddProfessor([FromBody] Professor p)
        {
            var resp = await _service.AddProfessor(p);
            return Ok(resp);
        }
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateProfessor([FromRoute] string id, [FromBody] Professor p)
        {
            var resp = await _service.UpdateProfessor(id, p);
            return Ok(resp);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteProfessor([FromRoute] string id)
        {
            await _service.DeleteProfessor(id);
            return NoContent();
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetProfessor([FromRoute] string id)
        {
            var resp = await _service.GetProfessorById(id);
            return Ok(resp);
        }
    }
}
