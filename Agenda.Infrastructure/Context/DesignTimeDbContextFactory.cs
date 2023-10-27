using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Infrastructure.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AgendaContext>
    {
        public AgendaContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<AgendaContext>()
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<AgendaContext>();
            var connectionString =
                config.GetConnectionString("AgenteApi");
            builder.UseSqlServer(connectionString);
            Console.WriteLine(connectionString);
            return new AgendaContext(builder.Options);
        }
    }
}
