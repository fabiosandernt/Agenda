using Agenda.Application.Agenda.Dtos;
using Agenda.Domain.Agendas;
using Agenda.Domain.Agendas.Repository;
using AutoMapper;

namespace Agenda.Application.Agenda.Services
{
    public class AgendaService : IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMapper _mapper;

        public AgendaService(IAgendaRepository agendaRepository, IMapper mapper)
        {
            _agendaRepository = agendaRepository;
            _mapper = mapper;
        }

        public async Task<AgendaBookDto> CreateAgendaAsync(AgendaBookDto dto)
        {

            var agenda = _mapper.Map<AgendaBook>(dto);
            await _agendaRepository.AddAsync(agenda);
            return _mapper.Map<AgendaBookDto>(agenda);
        }

        public async Task<AgendaBookDto> GetAgendaBookByIdAsync(Guid id)
        {
            if (id == null)
                throw new Exception("Id null, favor informar id");

            var agenda = await _agendaRepository.GetByIdAsync(id);

            return _mapper.Map<AgendaBookDto>(agenda);
        }       
    }
}