using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Agenda.Dtos
{
    public class AgendaBookDto
    {
        public  Guid Id { get; set; }
        public string Nome { get; set; }
        public virtual List<ContatoDto> ContatosDto { get; set; } = new List<ContatoDto>();

    }
}
