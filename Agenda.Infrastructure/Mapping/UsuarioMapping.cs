using Agenda.Domain.Agendas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x=>x.TipoUsuario).IsRequired();

            builder.HasMany(x => x.AgendaBooks).WithOne(x => x.Usuario);

            builder.OwnsOne(x => x.Email, p =>
            {
                p.Property(f => f.Valor).HasColumnName("Email").IsRequired().HasMaxLength(1024);
            });
            builder.OwnsOne(x => x.Password, p =>
            {
                p.Property(f => f.Valor).HasColumnName("Password").IsRequired();
            });
        }
    }
}
