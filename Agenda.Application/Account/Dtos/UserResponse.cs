using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Account.Dtos
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string JwtToken { get; set; }
    }
}
