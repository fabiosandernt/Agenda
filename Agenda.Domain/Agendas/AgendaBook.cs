using Agenda.Domain.Base;

namespace Agenda.Domain.Agendas
{
    public class AgendaBook : Entity
    {
        public string Nome { get; protected set; }
        protected List<Contato> Contatos { get; private set; } = new List<Contato>();
        public Compromisso Compromisso { get; private set; }
        public AgendaBook(string nome)
        {
            Nome = nome;
            Contatos = new List<Contato>();
        }
        public IReadOnlyList<Contato> GetContatos()
        {
            return Contatos.AsReadOnly();
        }
        public void AdicionarContato(Contato contato)
        {
            Contatos.Add(contato);
        }

        public void RemoverContato(Contato contato)
        {
            Contatos.Remove(contato);
        }

        public void AdicionarCompromisso(Compromisso compromisso)
        {
            Compromisso = compromisso;
        }
    }      
}
