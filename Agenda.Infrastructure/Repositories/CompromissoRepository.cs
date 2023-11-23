using Agenda.Domain.Agendas.Repository;
using Agenda.Domain.Agendas;
using Agenda.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Repositories
{
    public class CompromissoRepository : Repository<Compromisso>, ICompromissoRepository
    {
        public CompromissoRepository(AgendaContext context) : base(context)
        {
        }
        public async Task<List<Compromisso>> GetAllWithAgenda()
        {
            var compromissos = await this.Query.Include(x => x.Agenda).ToListAsync();
            return compromissos;
        }
        public async Task<Compromisso> GetByIdWithAgenda(Guid id)
        {
            var compromisso = await Query.Include(x => x.Agenda)
                .FirstOrDefaultAsync(x => x.Id == id);
            return compromisso;
        }
    }
}
