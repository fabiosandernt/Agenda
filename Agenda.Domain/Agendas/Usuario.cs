using Agenda.Domain.Agendas.Enum;
using Agenda.Domain.Agendas.Rules;
using Agenda.Domain.Agendas.ValueObject;
using Agenda.Domain.Base;
using FluentValidation;
using System.ComponentModel;

namespace Agenda.Domain.Agendas
{
    public class Usuario: Entity
    {
        public string Nome { get; set; }
        public Email Email { get; set;}
        public Password Password { get; set;}

        public TipoUsuarioEnum TipoUsuario { get; set;}
        public List<AgendaBook> AgendaBooks { get; set; } = new List<AgendaBook>();    

        public void SetPassword()
        {
            this.Password.Valor = SecurityUtils.HashSHA1(this.Password.Valor);
        }

        public void Validate() =>
            new UsuarioValidator().ValidateAndThrow(this);

        

        //EF
        protected Usuario()
        {

        }

        public void Update(string nome, Email email, Password password)
        {
            Nome = nome;
            Email = email;
            Password = password;
        }
    }
}
