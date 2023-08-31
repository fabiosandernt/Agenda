using Agenda.Domain.Base;

namespace Agenda.Domain.Agendas
{
    public class Agenda: Entity
    {
        public string Nome { get; protected set; }
        protected List<Contato> Contatos { get; set; } = new List<Contato>();

        public Agenda(string nome)
        {
           Nome = nome;
           Contatos = new List<Contato>();
        }

        public void AdicionarContato(Contato contato)
        {
            Contatos.Add(contato);
        }

        public void RemoverContato(Contato contato)
        {
            Contatos.Remove(contato);
        }
    }
}
