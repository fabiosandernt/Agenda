using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Account.Services.JwtServices
{
    public class JwtDto
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public JwtDto(
            Guid id,
            string email
        )
        {
            Id = id;
            Email = email;
        }
    }
}
