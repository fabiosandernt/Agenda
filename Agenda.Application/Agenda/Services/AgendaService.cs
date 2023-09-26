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

        
    }
}
