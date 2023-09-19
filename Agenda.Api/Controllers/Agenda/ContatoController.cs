using Agenda.Application.Agenda.Dtos;
using Agenda.Application.Agenda.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Api.Controllers.Agenda
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;
        private readonly IAgendaService _agendaService;

        public ContatoController(IContatoService contatoService, IAgendaService agendaService)
        {
            _contatoService = contatoService;
            _agendaService = agendaService;
        }

        [HttpPost("criar")] 
        public async Task<IActionResult> CriarContatoAsync([FromQuery] ContatoDto contatoDto)
        {
            try
            {
                if (contatoDto == null)
                {
                    return BadRequest("Dados de contato inválidos.");
                }

               
               var novoContato = await _contatoService.CreateContatoAsync(contatoDto);

                return Ok(novoContato);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno.");
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
