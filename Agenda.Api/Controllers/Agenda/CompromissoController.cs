using Agenda.Application.Agenda.Dtos;
using Agenda.Application.Agenda.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Api.Controllers.Agenda
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CompromissoController : ControllerBase
    {
        private readonly ICompromissoService _compromissoService;

        public CompromissoController(ICompromissoService compromissoService)
        {
            _compromissoService = compromissoService;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CriarCompromissoAsync([FromQuery] CompromissoDto compromissoDto, Guid id)
        {
            try
            {
                if (compromissoDto == null)
                    return BadRequest("Dados de compromisso inválidos.");

                var novoCompromisso = await _compromissoService.CreateCompromissoAsync(compromissoDto, id);

                return Ok(novoCompromisso);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno.");
            }
        }
        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarCompromissoAsync(Guid id, [FromQuery] CompromissoDto dto)
        {
            try
            {
                var compromissoAtualizado = await _compromissoService.UpdateCompromissoAsync(id,dto);
                return Ok(compromissoAtualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno");
            }
        }

        [HttpDelete("deletar")]
        public async Task<IActionResult> DeletarCompromissoAsync(Guid id)
        {
            try
            {
                var result = await _compromissoService.DeleteCompromissoAsync(id);
                return Ok("Compromisso excluido com sucesso");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                var compromisso = await _compromissoService.GetById(id);
                return Ok(compromisso);
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError,"Ocorreu um erro interno");
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var compromissos = await _compromissoService.GetAllAsync();

                if (compromissos == null || !compromissos.Any())
                {
                    return NotFound("Nenhum contato encontrado.");
                }

                return Ok(compromissos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno.");
            }
        }

    }
}
