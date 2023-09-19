using Agenda.Application.Agenda.Dtos;
using Agenda.Domain.Agendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Agenda.Services
{
    public interface IAgendaService
    {
        Task<ContatoDto> CriarContatoAsync(ContatoDto contatoDto);
    }
}
