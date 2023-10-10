using Agenda.Application.Agenda.Dtos;

namespace Agenda.Application.Agenda.Services
{
    public interface IAgendaService
    {
        Task<AgendaBookDto> GetAgendaBookByIdAsync(Guid Id);
        Task<AgendaBookDto> CreateAgendaAsync (AgendaBookDto agendadto);
    }
}
