using Agenda.Domain.Base;

namespace Agenda.Domain.Agendas
{
    public class Usuario: Entity
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
