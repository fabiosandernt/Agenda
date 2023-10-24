using Agenda.Application.Account.Dtos;
using Agenda.Domain.Agendas;
using Agenda.Domain.Agendas.Repository;
using AutoMapper;

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
                throw new Exception("Já existe um usuário com este nome cadastrado");
            try
            {
                var usuario = _mapper.Map<Usuario>(dto);
                usuario.Validate();
                usuario.SetPassword();
                await _usuarioRepository.AddAsync(usuario);
                return _mapper.Map<UsuarioDto>(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<UsuarioDto> UpdateUsuarioAsync(Guid id, UsuarioDto dto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            usuario.Update(dto.Nome,dto.Email,dto.Password);
            usuario.Validate();
            usuario.SetPassword();
            if (usuario == null)

            {
                throw new Exception("Usuario não existe");
            }
            await _usuarioRepository.UpdateAsync(usuario);
            return _mapper.Map<UsuarioDto>(usuario);

        }

        public async Task<UsuarioDto> DeleteUsuarioAsync(Guid id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                throw new Exception("Usuario não existe");
            }
            await _usuarioRepository.DeleteAsync(id);
            return null;
        }

        public async Task<UsuarioDto> GetById(Guid id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                throw new Exception("Usuario não existe");

            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<List<UsuarioDto>> GetAllAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();

            return _mapper.Map<List<UsuarioDto>>(usuarios);
        }
    }
}

