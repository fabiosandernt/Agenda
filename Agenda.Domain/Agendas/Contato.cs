using Agenda.Domain.Base;

namespace Agenda.Domain.Agendas
{
    public class Contato: Entity
    {
        protected Contato() { } 
        public Contato(string nome, string telefone)
        {
            Nome = nome;
            Telefone = telefone;
        }

        public string Nome { get; }
        public string Telefone { get; }

    }
}
