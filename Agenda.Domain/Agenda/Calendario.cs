using Agenda.Domain.Agendas;
using Agenda.Domain.Base;

namespace Agenda.Domain.Agenda
{
    public class Calendario: Entity<Guid>
    {
        public string Nome { get; set; }
        private readonly List<Compromisso> _compromisso = new List<Compromisso>();
        
        public void AdicionarCompromisso(Compromisso compromisso)
        {
            //Logica
            _compromisso.Add(compromisso);
        }

        public void RemoverCompromisso(Compromisso compromisso)
        {
            //Logica
            _compromisso.Add(compromisso);
        }
    }
}
