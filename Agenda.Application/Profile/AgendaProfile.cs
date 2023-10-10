using Agenda.Application.Account.Dtos;
using Agenda.Application.Agenda.Dtos;
using Agenda.Domain.Agendas;

namespace Agenda.Application.Profile
{
    public class AgendaProfile : AutoMapper.Profile
    {
        public AgendaProfile() 
        {
            CreateMap<Contato, ContatoDto>();
            CreateMap<ContatoDto, Contato>();
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<AgendaBook, AgendaBookDto>();
            CreateMap<AgendaBookDto, AgendaBook>();
            CreateMap<Compromisso, CompromissoDto>();
            CreateMap<CompromissoDto, Compromisso>();
        }  
    }
}
