using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RandevumAPI.Interface;
using RandevumAPI.Objects.DTO;
using System.Threading.Tasks;
using RandevumAPI.Objects.CustomExceptions;

namespace RandevumAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate(LoginDTO model)
        {
            var user = await _loginService.Login(model);

            return Ok(user);
        }
    }
}