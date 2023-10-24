using Agenda.Application.Account.Dtos;


namespace Agenda.Application.Account.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> CreateUsuarioAsync(UsuarioDto dto);
        Task<List<UsuarioDto>> GetAllAsync();
        Task<UsuarioDto> GetById(Guid id);
        Task<UsuarioDto> UpdateUsuarioAsync(Guid id, UsuarioDto dto);
        Task<UsuarioDto> DeleteUsuarioAsync(Guid id);
    }
}
