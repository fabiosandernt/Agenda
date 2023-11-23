using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Agenda.Infrastructure.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AgendaContext>
    {
        public AgendaContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                //.AddUserSecrets<AgendaContext>()
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<AgendaContext>();
            var connectionString =
                config.GetConnectionString("AgendaApi");
            builder.UseSqlServer(connectionString);
            Console.WriteLine(connectionString);
            return new AgendaContext(builder.Options);
        }
    }
}
