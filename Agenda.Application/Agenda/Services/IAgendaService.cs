using Agenda.Application.Account.Dtos;
using Agenda.Application.Agenda.Dtos;

namespace Agenda.Application.Agenda.Services
{
    public interface IAgendaService
    {
        Task<AgendaBookDto> GetAgendaBookByIdAsync(Guid Id);
        Task<AgendaBookDto> CreateAgendaAsync (AgendaBookDto agendadto);
        Task<List<AgendaBookDto>> GetAllAsync();
        Task<AgendaBookDto> UpdateAgendaAsync(Guid id, AgendaBookDto dto);
        Task<AgendaBookDto> DeleteAgendaAsync(Guid id);
    }
}
