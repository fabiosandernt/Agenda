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

        public async Task<IActionResult> CreateAgendaBookAsync([FromQuery] AgendaBookDto agendaBookDto)
        {
            try
            {
                if ( agendaBookDto == null)
                {
                    return BadRequest("Dados inválidos.");
                }
                var novaAgenda = await _agendaService.CreateAgendaAsync(agendaBookDto);

                return Ok(novaAgenda);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Ocorreu um erro interno.");
            }
        }
    }
}
