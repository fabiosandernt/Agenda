using Agenda.Application.Account.Dtos;
using Agenda.Application.Agenda.Dtos;
using Agenda.Domain.Agendas;

namespace Agenda.Application.Profile
{
    public class AgendaProfile : AutoMapper.Profile
    {
        public AgendaProfile()
        {
            CreateMap<Contato, ContatoDto>()
                .ForMember(dest => dest.AgendaDto, opt => opt.MapFrom(src => src.Agenda));
            CreateMap<ContatoDto, Contato>()
                .ForMember(dest => dest.Agenda, opt => opt.MapFrom(src => src.AgendaDto));
            CreateMap<Usuario, UsuarioDto>()
                .ForMember(dest => dest.AgendaDtos, opt => opt.MapFrom(src => src.AgendaBooks));
            CreateMap<UsuarioDto, Usuario>()
                .ForMember(dest => dest.AgendaBooks, opt => opt.MapFrom(src => src.AgendaDtos));
            CreateMap<AgendaBook, AgendaBookDto>()
                .ForMember(dest => dest.UsuarioDto, opt => opt.MapFrom(src => src.Usuario));
            CreateMap<AgendaBookDto, AgendaBook>()
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.UsuarioDto));
            CreateMap<Compromisso, CompromissoDto>()
                  .ForMember(dest => dest.AgendaDto, opt => opt.MapFrom(src => src.Agenda));
            CreateMap<CompromissoDto, Compromisso>()
                  .ForMember(dest => dest.Agenda, opt => opt.MapFrom(src => src.AgendaDto));
        }
    }
}