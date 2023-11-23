using Agenda.Domain.Base;

namespace Agenda.Domain.Agendas.Repository
{
    public interface IAgendaRepository :  IRepository<AgendaBook>
    {
        Task <List<AgendaBook>> GetAllWithUserName();
        Task<AgendaBook> GetByIdWithUserName(Guid id);
    }
}
