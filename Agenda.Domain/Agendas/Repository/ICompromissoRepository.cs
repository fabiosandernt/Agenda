﻿using Agenda.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.Agendas.Repository
{
    public interface ICompromissoRepository : IRepository<Compromisso>
    {
        Task<List<Compromisso>> GetAllWithAgenda();
        Task<Compromisso> GetByIdWithAgenda(Guid id);
    }
}
