using Agenda.Domain.Agendas.Repository;
using Agenda.Domain.Agendas;
using Agenda.Infrastructure.Context;
using Agenda.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Infrastructure.Repositories
{
    public class AgendaRepository : Repository<AgendaBook>, IAgendaRepository
    {
        public AgendaRepository(AgendaContext context) : base(context)
        {
        }
    }
}
