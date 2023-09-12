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
    }
}
