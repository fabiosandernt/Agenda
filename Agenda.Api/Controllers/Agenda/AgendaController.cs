using Agenda.Application.Account.Dtos;
using Agenda.Application.Agenda.Dtos;
using Agenda.Application.Agenda.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Api.Controllers.Agenda
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaService _agendaService;

        public AgendaController(IAgendaService agendaService)
        {
            _agendaService = agendaService;
        }
        
        [HttpPost("criar")]

        public async Task<IActionResult> CreateAgendaBookAsync([FromQuery] AgendaBookDto agendadto)
        {
            try
            {
                if ( agendadto == null)
                {
                    return BadRequest("Dados inválidos.");
                }
                var novaAgenda = await _agendaService.CreateAgendaAsync(agendadto);

                return Ok(novaAgenda);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Ocorreu um erro interno.");
            }
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateAgendaAsync(Guid id, [FromQuery] AgendaBookDto dto)
        {
            try
            {
                var agendaAtualizada = await _agendaService.UpdateAgendaAsync(id, dto);
                return Ok(agendaAtualizada);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Ocorreu um erro interno");
            }
        }

        [HttpDelete("deletar")]
        public async Task<IActionResult> DeleteAgendaAsync(Guid id)
        {
            try
            {
                var result = await _agendaService.DeleteAgendaAsync(id);
                return Ok("Agenda excluida com sucesso");
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Ocorreu um erro interno");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAgendaBookByIdAsync([FromRoute] Guid id)
        {
            try
            {
                var agenda = await _agendaService.GetAgendaBookByIdAsync(id);
                return Ok(agenda);
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
                var agendas = await _agendaService.GetAllAsync();

                if (agendas == null || !agendas.Any())
                {
                    return NotFound("Nenhuma agenda encontrada.");
                }

                return Ok(agendas);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno.");
            }
        }
         
    }
}

