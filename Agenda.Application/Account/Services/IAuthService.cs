using Agenda.Application.Account.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Account.Services
{
    public interface IAuthService
    {
        Task<UserResponse> LoginAsync(LoginRequest request);
    }
}
