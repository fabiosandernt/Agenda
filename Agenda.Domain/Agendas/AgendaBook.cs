using Agenda.Domain.Base;

namespace Agenda.Domain.Agendas
{
    public class AgendaBook : Entity
    {
        public string Nome { get; }
        private List<Contato> Contatos { get; } = new List<Contato>();
        public Compromisso Compromisso { get; private set; }


        private AgendaBook()
        {
        }
        public AgendaBook(string nome)
        {
            Nome = nome;
        }

        public IReadOnlyList<Contato> GetContatos()
        {
            return Contatos.AsReadOnly();
        }

        public void AdicionarContato(Contato contato)
        {
            if (!Contatos.Contains(contato))
                Contatos.Add(contato);
        }

        public void RemoverContato(Contato contato)
        {
            Contatos.Remove(contato);
        }
        public void AdicionarCompromisso(Compromisso compromisso)
        {
            if (Compromisso == null)
                Compromisso = compromisso;
            else
                throw new InvalidOperationException("Já existe um compromisso nesta agenda.");
        }

        public void RemoverCompromisso()
        {
            Compromisso = null;
        }
    }      
}
