using Agenda.Application.Agenda.Dtos;


namespace Agenda.Application.Agenda.Services
{
    public interface IContatoService
    {
        Task<ContatoDto>  CreateContatoAsync (ContatoDto contato);
        Task<List<ContatoDto>> GetAllAsync ();
    }
}
