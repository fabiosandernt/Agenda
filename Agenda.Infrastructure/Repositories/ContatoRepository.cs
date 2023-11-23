using Agenda.Domain.Agendas;
using Agenda.Domain.Agendas.Repository;
using Agenda.Infrastructure.Context;
using Agenda.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Infrastructure.Repositories
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(AgendaContext context) : base(context)
        {
        }

        public async Task<List<Contato>> GetWithIncludeAgenda()
        {
            var contatos = await this.Query.Include(x => x.Agenda).ToListAsync();
            return contatos;
        }
        public async Task<Contato> GetByIdWithIncludeAgenda(Guid id)
        {
            var contato = await Query.Include(x => x.Agenda)
                .FirstOrDefaultAsync(x=>x.Id==id);
            return contato;
        }
    }
}