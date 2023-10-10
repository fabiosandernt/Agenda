using Agenda.Application.Account.Dtos;
using Agenda.Domain.Agendas;
using Agenda.Domain.Agendas.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Account.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDto> CreateUsuarioAsync(UsuarioDto dto)
        {
            if (await _usuarioRepository.AnyAsync(x => x.Nome == dto.Nome))
                throw new Exception("Já existe este contato cadastrado");
            try
            {
                var usuario = _mapper.Map<Usuario>(dto);

                await _usuarioRepository.AddAsync(usuario);
                return _mapper.Map<UsuarioDto>(usuario);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
