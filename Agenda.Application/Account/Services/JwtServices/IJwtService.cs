using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Account.Services.JwtServices
{
    public interface IJwtService
    {
        Task<string> GenerateToken(JwtDto jwtDto);
        Task<JwtTokenViewModel> ReadTokenAsync(string token);
    }
}
