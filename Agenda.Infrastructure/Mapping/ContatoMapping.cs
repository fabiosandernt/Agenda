using Agenda.Domain.Agendas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Mapping
{
    public class ContatoMapping : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contatos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Telefone);
            builder.Property(x => x.Nome);            
      
        }
    }
}
