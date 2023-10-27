using Agenda.Domain.Agendas.Repository;
using Agenda.Domain.Agendas;
using Agenda.Infrastructure.Context;
using Agenda.Infrastructure.Database;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AgendaContext context) : base(context)
        {
        }

        public async Task<Usuario> GetByExpressionAsync(Expression<Func<Usuario, bool>> expression)
        {
            return await this.Query.FirstOrDefaultAsync(expression);
        }
    }
}
