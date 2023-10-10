using Agenda.Application.Account.Dtos;
using Agenda.Application.Account.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Api.Controllers.Account
{
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioservice;

        public UsuarioController (IUsuarioService usuarioservice)
        {
            _usuarioservice = usuarioservice;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CriarUsuarioAsync([FromQuery]UsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                    return BadRequest("Dados de usuario invalidos");

                var novoUsuario = await _usuarioservice.CreateUsuarioAsync(usuarioDto);
                return Ok(novoUsuario);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Ocorreu um erro interno.");
            }
        }
    }
}
