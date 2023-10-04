using Agenda.Domain.Base;

namespace Agenda.Domain.Agendas
{
    public class Usuario: Entity
    {
        public string Nome { get; set; }
        public string Email { get; set;}
        public List<AgendaBook> AgendaBooks { get; set; } = new List<AgendaBook>();    
        public void Update(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
