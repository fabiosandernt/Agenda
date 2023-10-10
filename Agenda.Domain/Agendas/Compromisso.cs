using Agenda.Domain.Base;

namespace Agenda.Domain.Agendas
{
    public class Compromisso : Entity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime HoraDeInicio { get; set; }
        public DateTime HoraDeTermino { get; set; }

        public Guid AgendaId { get; set; }
        public AgendaBook Agenda { get; set; }

        //EF
        protected Compromisso() { }
        //public void Reagendar(DateTime novaHoraDeInicio, DateTime novaHoraDeTermino)
        //{
            //if (novaHoraDeInicio < novaHoraDeTermino)
            //{
                //HoraDeInicio = novaHoraDeInicio;
                //HoraDeTermino = novaHoraDeTermino;
            //}
            //else
            //{
                //throw new ArgumentException("A hora de término deve ser posterior à hora de início.");
            //}
        //}
    }
}
