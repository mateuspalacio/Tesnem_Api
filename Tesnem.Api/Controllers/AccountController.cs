using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tesnem.Api.Domain.Auth;
using Tesnem.Api.Domain.Exceptions;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
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
        [Route("register/student")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterStudent([FromBody]UserRegistration userModel)
        {
            var user = _mapper.Map<User>(userModel);

            try
            {
                var result = await _userManager.CreateAsync(user, userModel.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        throw new ErrorException(ExceptionMessages.BadRegisterRequestMessage, error.Description);
                    }
                }
            } catch (Exception ex)
            {
                throw;
            }
            await _userManager.AddToRoleAsync(user, "Student");

            return NoContent();
        }
        [HttpPost]
        [Route("register/professor")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterProfessor([FromBody] UserRegistration userModel)
        {
            var user = _mapper.Map<User>(userModel);

            try
            {
                var result = await _userManager.CreateAsync(user, userModel.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        throw new ErrorException(ExceptionMessages.BadRegisterRequestMessage, error.Description);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            await _userManager.AddToRoleAsync(user, "Professor");

            return NoContent();
        }
        [HttpPost]
        [Route("register/admin")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAdmin([FromBody] UserRegistration userModel)
        {
            var user = _mapper.Map<User>(userModel);

            try
            {
                var result = await _userManager.CreateAsync(user, userModel.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        throw new ErrorException(ExceptionMessages.BadRegisterRequestMessage, error.Description);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            await _userManager.AddToRoleAsync(user, "Administrator");

            return NoContent();
        }

        [HttpPost]
        [Route("login")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody] UserLogin userModel)
        {
            var user = await _userManager.FindByNameAsync(userModel.UserName);
            var valid = await _userManager.CheckPasswordAsync(user, userModel.Password);
            if (user != null && valid)
            {
                var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                    new ClaimsPrincipal(identity));
                return NoContent();
            }
            else
            {
                throw new ErrorException(ExceptionMessages.BadLoginRequestMessage, null);
            }
        }
    }
}
