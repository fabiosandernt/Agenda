﻿using Agenda.Domain.Agendas.ValueObject;
using Agenda.Domain.Base;

namespace Agenda.Domain.Agendas
{
    public class AgendaBook : Entity
    {
        public string Nome { get; set; }

        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public List<Contato> Contatos { get; set; } = new List<Contato>();       
        public List<Compromisso> Compromissos { get; set; } = new List<Compromisso>();

        //EF
        protected AgendaBook()
        {

        }
        public void Update(string nome)
        {
            Nome = nome;
        }
        
    }      
}
