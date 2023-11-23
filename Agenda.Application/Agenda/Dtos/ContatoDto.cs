using Agenda.Domain.Agendas;

namespace Agenda.Application.Agenda.Dtos
{
    public class ContatoDto
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Guid AgendaId { get; set; }
        public AgendaBookDto? AgendaDto { get; set; }
    }
}
