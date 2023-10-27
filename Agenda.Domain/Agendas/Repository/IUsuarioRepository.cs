using Agenda.Domain.Base;
using System.Linq.Expressions;

namespace Agenda.Domain.Agendas.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> GetByExpressionAsync(Expression<Func<Usuario, bool>> expression); 
    }
}
