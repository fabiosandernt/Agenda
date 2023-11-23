using Agenda.Domain.Agendas;

namespace Agenda.Application.Agenda.Dtos
{
    public class CompromissoDto
    {
        public Guid? Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime HoraDeInicio { get; set; }
        public DateTime HoraDeTermino { get; set; }
        public Guid AgendaId { get; set; }
        public AgendaBookDto? AgendaDto { get; set; }
    }
}
