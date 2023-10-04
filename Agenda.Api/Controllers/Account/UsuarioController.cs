using Agenda.Application.Account.Dtos;
using Agenda.Application.Account.Services;
using Agenda.Application.Agenda.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Api.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CriarUsuarioAsync(UsuarioDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("Dados de contato inválidos.");
                }

                var usuario = await _usuarioService.CreateUsuarioAsync(dto);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Ocorreu um erro interno.");
            }
        }
    }
}
