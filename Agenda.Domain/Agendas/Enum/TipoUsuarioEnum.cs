using System.ComponentModel;

namespace Agenda.Domain.Agendas.Enum
{
    public enum TipoUsuarioEnum: int
    {
        [Description("Adminstrador")]
        Administrador = 1,

        [Description("Cliente")]
        Cliente = 2,

    }
}
