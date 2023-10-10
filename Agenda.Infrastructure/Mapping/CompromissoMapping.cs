using Agenda.Domain.Agendas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Infrastructure.Mapping
{
    public class CompromissoMapping : IEntityTypeConfiguration<Compromisso>
    {
        public void Configure(EntityTypeBuilder<Compromisso> builder)
        {
            builder.ToTable("Compromisso");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Titulo);
            builder.Property(x => x.Descricao);
            builder.Property(x => x.HoraDeInicio);
            builder.Property(x => x.HoraDeTermino);
        }
    }
}
