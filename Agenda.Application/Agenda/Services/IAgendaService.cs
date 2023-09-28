

using Agenda.Application.Agenda.Dtos;
using Agenda.Domain.Agendas;

namespace Agenda.Application.Agenda.Services
{
    public interface IAgendaService
    {
        Task<AgendaBookDto> GetAgendaBookByIdAsync(Guid id);
    }
}
