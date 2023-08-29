using Agenda.Domain.Base;

namespace Agenda.Domain.Agendas
{
    public class Compromisso : Entity<Guid>
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime HoraDeInicio {get; set; }
        public DateTime HoraDeTermino { get; set; }
           
        public void Reagendar(DateTime novaHoraDeInicio, DateTime novaHoraDeTermino)
        {
            HoraDeInicio = novaHoraDeInicio;
            HoraDeTermino = novaHoraDeTermino;
        }
    }
}
