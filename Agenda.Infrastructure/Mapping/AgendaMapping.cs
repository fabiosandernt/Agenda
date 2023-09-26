using Agenda.Domain.Agendas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Mapping
{
    public class AgendaMapping: IEntityTypeConfiguration<AgendaBookDto>
    {
        public void Configure(EntityTypeBuilder<AgendaBookDto> builder) 
        {
            builder.ToTable("Agendas");
            builder.HasKey(a => a.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome);

            builder.HasMany(x => x.Contatos).WithOne(x => x.Agenda);
            builder.HasMany(x=>x.Compromissos).WithOne(x=>x.Agenda);
        }
    }
}
