using Agenda.Application.Account.Dtos;
using Agenda.Domain.Agendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Agenda.Dtos
{
    public class AgendaBookDto
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }

        public Guid? UsuarioId { get; set; }
        public UsuarioDto? UsuarioDto { get; set; }

        public List<ContatoDto> ContatosDto { get; set; } = new List<ContatoDto>();
        public List<CompromissoDto> CompromissosDto { get; set; } = new List<CompromissoDto>();
    }
}