using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tesnem.Api.Domain.Auth;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public AccountController(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        [HttpPost]
        [Route("student")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterStudent([FromBody]UserRegistration userModel)
        {
            var user = _mapper.Map<User>(userModel);

            var result = await _userManager.CreateAsync(user, userModel.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
            }

            await _userManager.AddToRoleAsync(user, "Student");

            return Ok(result);
        }
    }
}
