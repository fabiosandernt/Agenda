using Agenda.Domain.Base;

namespace Agenda.Domain.Agendas
{
    public class Calendario: Entity
    {
        public string Nome { get; }
        private readonly List<Compromisso> _compromissos = new List<Compromisso>();
        protected Calendario() { }
        public Calendario(string nome)
        {
            Nome = nome;
        }

        public IReadOnlyList<Compromisso> GetCompromissos()
        {
            return _compromissos.AsReadOnly();
        }

        public void AdicionarCompromisso(Compromisso compromisso)
        {
            if (!_compromissos.Contains(compromisso))
                _compromissos.Add(compromisso);
        }

        public void RemoverCompromisso(Compromisso compromisso)
        {
            _compromissos.Remove(compromisso);
        }
    }
}
