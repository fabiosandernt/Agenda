using Agenda.Application.Agenda.Dtos;
using Agenda.Domain.Agendas;
using Agenda.Domain.Agendas.Repository;
using AutoMapper;

namespace Agenda.Application.Agenda.Services
{
    public class AgendaService : IAgendaService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMapper _mapper;

        public AgendaService(IContatoRepository contatoRepository, IAgendaRepository agendaRepository, IMapper mapper)
        {
            _contatoRepository = contatoRepository;
            _agendaRepository = agendaRepository;
            _mapper = mapper;
        }

        public async Task<ContatoDto> CriarContatoAsync(ContatoDto contatoDto)
        {
          
            var contato = _mapper.Map<Contato>(contatoDto);
            
            var agenda = new AgendaBook("Joaquim");
                        
            agenda.AdicionarContato(contato);            

            await _agendaRepository.AddAsync(agenda);
            
            var novoContatoDto = _mapper.Map<ContatoDto>(contato);

            return novoContatoDto;
        }
    }
}
