using Agenda.Domain.Base;

namespace Agenda.Domain.Agendas
{
    public class AgendaBook : Entity
    {
        public string Nome { get; set; }   
        
        public virtual List<Contato> Contatos { get; set; } = new List<Contato>();       
        public virtual List<Compromisso> Compromissos { get; set; } = new List<Compromisso>();

        //EF
        public AgendaBook()
        {

        }        
    }      
}
