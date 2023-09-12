using Agenda.Application.Agenda.Dtos;


namespace Agenda.Application.Agenda.Services
{
    public interface IContatoService
    {
        Task<ContatoDto>  Create (ContatoDto contato);
        Task<List<ContatoDto>> GetAllAsync ();
    }
}
