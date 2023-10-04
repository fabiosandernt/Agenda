﻿using Agenda.Application.Account.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Account.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> CreateUsuarioAsync(UsuarioDto dto);
        Task<List<UsuarioDto>> GetAllAsync();
    }
}
