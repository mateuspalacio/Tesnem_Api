using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tesnem.Api.Domain.DTO;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.DTO.ResponseDTO;
using Tesnem.Api.Domain.Models;
using Tesnem.Api.Domain.Repository;
using Tesnem.Api.Domain.Services;

namespace Tesnem.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _service;
        public ClassController(IClassService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddClass([FromBody] ClassRequest s)
        {
            var resp = await _service.AddClass(s);
            return Ok(resp);
        }
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateClass([FromRoute] Guid id, [FromBody] ClassRequest s)
        {
            var resp = await _service.UpdateClass(id, s);
            return Ok(resp);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteClass([FromRoute] Guid id)
        {
            await _service.DeleteClass(id);
            return NoContent();
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetClass([FromRoute] Guid id)
        {
            var resp = await _service.GetClassById(id);
            return Ok(resp);
        }
        [HttpDelete]
        [Route("delete/list")]
        public async Task<ActionResult<IEnumerable<DeleteListResponse>>> DeleteClasses([FromBody] DeleteListRequest list)
        {
            var resp = await _service.DeleteMultipleClasses(list.DeleteList);
            return Ok(resp);
        }
        [HttpGet]
        [Route("get/all")]
        public async Task<ActionResult<IEnumerable<ClassResponse>>> GetAllClasses()
        {
            var resp = await _service.GetAllClasses();
            return Ok(resp);
        }
    }
}
