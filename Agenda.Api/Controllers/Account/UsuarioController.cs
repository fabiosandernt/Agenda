using Agenda.Application.Account.Dtos;
using Agenda.Application.Account.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Api.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController (IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CriarUsuarioAsync([FromQuery]UsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                    return BadRequest("Dados de usuario invalidos");

                var novoUsuario = await _usuarioService.CreateUsuarioAsync(usuarioDto);
                return Ok(novoUsuario);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Ocorreu um erro interno.");
            }
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateUsuarioAsync(Guid id, [FromQuery] UsuarioDto dto)
        {
            try
            {
                var usuarioAtualizado = await _usuarioService.UpdateUsuarioAsync(id,dto);
                return Ok(usuarioAtualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Ocorreu um erro interno");
            }
        }

        [HttpDelete("deletar")]
        public async Task<IActionResult> DeleteUsuarioAsync(Guid id)
        {
            try
            {
                var result = await _usuarioService.DeleteUsuarioAsync(id);
                return Ok("Usuario excluido com sucesso");
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Ocorreu um erro interno");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                var usuario = await _usuarioService.GetById(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var usuarios = await _usuarioService.GetAllAsync();

                if (usuarios == null || !usuarios.Any())
                {
                    return NotFound("Nenhum usuario encontrado.");
                }

                return Ok(usuarios);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno.");
            }
        }
    }
}

