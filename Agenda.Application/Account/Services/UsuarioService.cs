using Agenda.Application.Account.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Account.Services
{
    public class UsuarioService : IUsuarioService
    {
        public Task<UsuarioDto> Create(UsuarioDto usuarioDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<UsuarioDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
