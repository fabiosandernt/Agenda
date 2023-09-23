using Agenda.Domain.Base;
using Agenda.Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq.Expressions;

namespace Agenda.Infrastructure.Database
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> Query { get; set; }
        protected DbContext Context { get; set; }

        public Repository(AgendaContext context)
        {
            Context = context;
            Query = Context.Set<T>();
        }


        public async Task AddAsync(T entity)
        {
            await Query.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return Query.AnyAsync(expression);      
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await Query.FindAsync(id);
            Query.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            var consulta = await Query.ToListAsync();
            return consulta;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Query.FindAsync(id);  
        }

        public async Task UpdateAsync(T entity)
        {
            Query.Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}
