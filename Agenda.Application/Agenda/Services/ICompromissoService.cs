using Agenda.Application.Agenda.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Agenda.Services
{
    public interface ICompromissoService
    {
        Task<CompromissoDto> CreateCompromissoAsync(CompromissoDto dto, Guid id);
        Task<List<CompromissoDto>> GetAllAsync();
        Task<CompromissoDto> GetById(Guid id);
        Task<CompromissoDto> UpdateCompromissoAsync(Guid id, CompromissoDto dto);
        Task<CompromissoDto> DeleteCompromissoAsync(Guid id);
    }
}
