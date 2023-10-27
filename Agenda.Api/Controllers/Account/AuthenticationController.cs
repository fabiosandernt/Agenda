using Agenda.Application.Account.Dtos;
using Agenda.Application.Account.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Api.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {        
        private readonly IUsuarioService _userService;
        private readonly IAuthService _authService;

        public AuthenticationController(IUsuarioService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login ([FromQuery] LoginRequest loginRequest)
        {
            try
            {
                var userRequest = await _authService.LoginAsync(loginRequest);
                if (userRequest == null)
                {
                    return Unauthorized(new {ErrorMessage = "Usuário ou senha inválidos" });
                }
                return Ok(userRequest);
            }
            catch (Exception ex)
            {

                return BadRequest(new { ErrorMessage = ex.Message });
            }
        } 
    }
}
