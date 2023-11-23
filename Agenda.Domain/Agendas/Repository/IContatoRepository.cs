using Agenda.Domain.Base;


namespace Agenda.Domain.Agendas.Repository
{
    public interface IContatoRepository : IRepository<Contato>
    {
        Task<List<Contato>> GetWithIncludeAgenda();
        Task<Contato> GetByIdWithIncludeAgenda(Guid id);
    }
}
