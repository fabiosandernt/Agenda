using Agenda.Domain.Base;

namespace Agenda.Domain.Agenda
{
    public class Usuario: Entity<Guid>
    {
        public string Nome { get; set; }
        public string Email { get; set;}
              
        public void Update(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
