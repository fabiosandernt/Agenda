using Agenda.Infrastructure.Context;
using Agenda.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Agenda.Infrastructure
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AgendaContext>(x =>
            {
                x.UseSqlServer(connectionString);
            });

            services.AddScoped(typeof(Repository<>));
            
            return services;
        }
    }
}
