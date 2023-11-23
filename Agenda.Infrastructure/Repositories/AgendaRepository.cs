using Agenda.Domain.Agendas.Repository;
using Agenda.Domain.Agendas;
using Agenda.Infrastructure.Context;
using Agenda.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Repositories
{
    public class AgendaRepository : Repository<AgendaBook>, IAgendaRepository
    {
        public AgendaRepository(AgendaContext context) : base(context)
        {
            
        }
        public async Task<List<AgendaBook>> GetAllWithUserName()
        {
            var agendas = await this.Query.Include(x => x.Usuario).ToListAsync();
            return agendas;
        }
        public async Task<AgendaBook> GetByIdWithUserName(Guid id)
        {
            var agenda = await Query.Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
            return agenda;
        }
    }
}
