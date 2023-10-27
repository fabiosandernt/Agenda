using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Account.Services.JwtServices
{
    public class JwtTokenViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }
}
