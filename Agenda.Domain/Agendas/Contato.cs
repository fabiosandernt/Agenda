using Agenda.Domain.Base;

namespace Agenda.Domain.Agendas
{
    public class Contato: Entity
    {
        public Contato(string nome, string telefone)
        {
            Nome = nome;
            Telefone = telefone;
        }

        public string Nome { get; set; }
        public string Telefone { get; set; }        

    }
}
