using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tesnem.Api.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
