using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.DTO.ResponseDTO;
using Tesnem.Api.Domain.Services;

namespace Tesnem.Api.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class MajorController : ControllerBase
    {
        private readonly IMajorService _service;
        public MajorController(IMajorService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddMajor([FromBody] MajorRequest s)
        {
            var resp = await _service.AddMajor(s);
            return Ok(resp);
        }
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateMajor([FromRoute] Guid id, [FromBody] MajorRequest s)
        {
            var resp = await _service.UpdateMajor(id, s);
            return Ok(resp);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteMajor([FromRoute] Guid id)
        {
            await _service.DeleteMajor(id);
            return NoContent();
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetMajor([FromRoute] Guid id)
        {
            var resp = await _service.GetMajorById(id);
            return Ok(resp);
        }
        [HttpGet]
        [Route("get/all")]
        public async Task<ActionResult<IEnumerable<MajorResponse>>> GetAllMajors()
        {
            var resp = await _service.GetAllMajors();
            return Ok(resp);
        }
        [HttpDelete]
        [Route("delete/list")]
        public async Task<ActionResult<IEnumerable<DeleteListResponse>>> DeleteMajors([FromBody] DeleteListRequest list)
        {
            var resp = await _service.DeleteMultipleMajors(list.DeleteList);
            return Ok(resp);
        }


    }
}
