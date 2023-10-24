using Agenda.Domain.Agendas;
using Agenda.Domain.Agendas.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Agenda.Infrastructure.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {
        }

        public DbSet<Compromisso> Compromissos { get; set; }
        public DbSet<Calendario> Calendarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<AgendaBook> Agendas { get; set; }
        public DbSet<Contato> Contatos { get; set; }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AgendaContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
