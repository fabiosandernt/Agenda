using Agenda.Application.Agenda.Dtos;
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

        public async Task<AgendaBookDto> GetAgendaBookByIdAsync(Guid id)
        {
            if (id == null)
                throw new Exception("Id null, favor informar id");

            var agenda = await _agendaRepository.GetByIdAsync(id);

            return _mapper.Map<AgendaBookDto>(agenda);
        }        
    }
}
