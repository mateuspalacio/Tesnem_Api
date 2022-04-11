using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.Services;

namespace Tesnem.Api.Controllers
{
    [Route("[controller]/")]
    [ApiController]
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


    }
}
