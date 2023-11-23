using Agenda.Application.Account.Dtos;
using Agenda.Application.Agenda.Dtos;
using Agenda.Domain.Agendas;
using Agenda.Domain.Agendas.Repository;
using Agenda.Infrastructure.Repositories;
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

        public async Task<AgendaBookDto> CreateAgendaAsync(AgendaBookDto agendadto)
        {
            if (agendadto == null)
                throw new Exception("Insira um nome válido");

            var agenda = _mapper.Map<AgendaBook>(agendadto);
            await _agendaRepository.AddAsync(agenda);
            return _mapper.Map<AgendaBookDto>(agenda);
        }

        public async Task<AgendaBookDto> GetAgendaBookByIdAsync(Guid id)
        {
            if (id == null)
                throw new Exception("Id null, favor informar id");

            var agenda = await _agendaRepository.GetByIdWithUserName(id);

            return _mapper.Map<AgendaBookDto>(agenda);
        }
        public async Task<AgendaBookDto> UpdateAgendaAsync(Guid id, AgendaBookDto dto)
        {
            var agenda = await _agendaRepository.GetByIdWithUserName(id);
            agenda.Update(dto.Nome);
            if (agenda == null)

            {
                throw new Exception("Agenda não existe");
            }
            await _agendaRepository.UpdateAsync(agenda);
            return _mapper.Map<AgendaBookDto>(agenda);

        }

        public async Task<AgendaBookDto> DeleteAgendaAsync(Guid id)
        {
            var agenda = await _agendaRepository.GetByIdWithUserName(id);
            if (agenda == null)
            {
                throw new Exception("Agenda não existe");
            }
            await _agendaRepository.DeleteAsync(id);
            return null;
        }

        public async Task<List<AgendaBookDto>> GetAllAsync()
        {
            var agendas = await _agendaRepository.GetAllWithUserName();

            return _mapper.Map<List<AgendaBookDto>>(agendas);
        }
    }
}