using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.Agendas.ValueObject
{
    public class Email
    {
        public string Valor { get; set; }
        public Email()
        {

        }
        public Email(string valor)
        {
            this.Valor = valor ?? throw new ArgumentNullException(nameof(Password));
        }
    }
}
