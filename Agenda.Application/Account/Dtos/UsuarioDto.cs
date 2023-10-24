

using Agenda.Domain.Agendas.Enum;
using Agenda.Domain.Agendas.ValueObject;
using Microsoft.AspNetCore.Identity;

namespace Agenda.Application.Account.Dtos
{
    public class UsuarioDto
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
    }
}
