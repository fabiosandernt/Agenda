using Agenda.Application.Agenda.Dtos;
using Agenda.Application.Agenda.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Api.Controllers.Agenda
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;
       
        public ContatoController(IContatoService contatoService)
        {
            _contatoService = contatoService;            
        }

        [HttpPost("criar")] 
        public async Task<IActionResult> CriarContatoAsync([FromQuery] ContatoDto contatoDto, Guid id)
        {
            try
            {
                if (contatoDto == null)
                    return BadRequest("Dados de contato inválidos.");

                var novoContato = await _contatoService.CreateContatoAsync(contatoDto, id);

                return Ok(novoContato);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Ocorreu um erro interno.");
            }
        }
        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateContatoAsync(Guid id, [FromQuery] ContatoDto dto)
        {
            try
            {
                var contatoAtualizado = await _contatoService.UpdateContatoAsync(id);
                return Ok(contatoAtualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Ocorreu um erro interno");
            }
        }

        [HttpDelete("deletar")]
        public async Task<IActionResult> DeleteContatoAsync(Guid id)
        {
            try
            {
                var result = await _contatoService.DeleteContatoAsync(id);
                return Ok("Contato excluido com sucesso");
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Ocorreu um erro interno");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            try
            {
                var contato = await _contatoService.GetById(id);
                return Ok(contato);
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
                var contatos = await _contatoService.GetAllAsync();

                if (contatos == null || !contatos.Any())
                {
                    return NotFound("Nenhum contato encontrado.");
                }

                return Ok(contatos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno.");
            }
        }
       
    }
}
