using Agenda.Domain.Base;

namespace Agenda.Domain.Agendas
{
    public class Contato: Entity
    {
        public string Nome { get; }
        public string Telefone { get; }
        public Guid AgendaId { get; set; }
        public AgendaBook Agenda { get; set; }
        protected Contato() 
        { 
        }
    }
}
