using Agenda.Domain.Agendas.ValueObject;
using Agenda.Domain.Base;

namespace Agenda.Domain.Agendas
{
    public class Contato: Entity
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Guid AgendaId { get; set; }
        public AgendaBook Agenda { get; set; }
        protected Contato() 
        { 
        }
        public void Update(string nome, string telefone)
        {
            Nome = nome;
            Telefone = telefone;
        }
    }
}
