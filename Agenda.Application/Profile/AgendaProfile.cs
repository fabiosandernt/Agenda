using Agenda.Application.Agenda.Dtos;
using Agenda.Domain.Agendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Profile
{
    public class AgendaProfile : AutoMapper.Profile
    {
        public AgendaProfile() 
        {
            CreateMap<Contato, ContatoDto>();
            CreateMap<ContatoDto, Contato>();
        }  
    }
}
