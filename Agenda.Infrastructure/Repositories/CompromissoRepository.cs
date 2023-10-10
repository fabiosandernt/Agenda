using Agenda.Domain.Agendas.Repository;
using Agenda.Domain.Agendas;
using Agenda.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Infrastructure.Context;

namespace Agenda.Infrastructure.Repositories
{
    public class CompromissoRepository : Repository<Compromisso>, ICompromissoRepository
    {
        public CompromissoRepository(AgendaContext context) : base(context)
        {
        }
    }
}
