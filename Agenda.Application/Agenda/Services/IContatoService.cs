﻿using Agenda.Application.Agenda.Dtos;


namespace Agenda.Application.Agenda.Services
{
    public interface IContatoService
    {
        Task<ContatoDto>  CreateContatoAsync (ContatoDto contato, Guid id);
        Task<List<ContatoDto>> GetAllAsync ();
        Task<ContatoDto> GetById(Guid id);
        Task<ContatoDto> UpdateContatoAsync(Guid id);
        Task<ContatoDto> DeleteContatoAsync(Guid id);
    }
}
