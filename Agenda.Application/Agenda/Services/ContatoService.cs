using Agenda.Application.Agenda.Dtos;
using Agenda.Domain.Agendas;
using Agenda.Domain.Agendas.Repository;
using AutoMapper;

namespace Agenda.Application.Agenda.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IContatoRepository _contatoRepository;
        private readonly IMapper _mapper;


        public ContatoService(IContatoRepository contatoRepository, IMapper mapper, IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
            _contatoRepository = contatoRepository;
            _mapper = mapper;
        }

        public async Task<ContatoDto> CreateContatoAsync(ContatoDto dto, Guid id)
        {
            
            if (await _contatoRepository.AnyAsync(x => x.Nome == dto.Nome))
                throw new Exception("Já existe este contato cadastrado");
            
            try
            {                
                var contato = _mapper.Map<Contato>(dto);
                var agenda = await _agendaRepository.GetByIdAsync(id);
                contato.AgendaId = agenda.Id;
                await _contatoRepository.AddAsync(contato);              
         
                return _mapper.Map<ContatoDto>(contato);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
        public async Task<ContatoDto> UpdateContatoAsync(Guid id, ContatoDto dto)
        {
            var contato = await _contatoRepository.GetByIdWithIncludeAgenda(id);
            if (contato == null)

            {
                throw new Exception("Contato não existe");
            }
            contato.Update(dto.Nome, dto.Telefone);
            await _contatoRepository.UpdateAsync(contato);
            return _mapper.Map<ContatoDto>(contato);

        }

        public async Task<ContatoDto> DeleteContatoAsync(Guid id)
        {
            var contato = await _contatoRepository.GetByIdWithIncludeAgenda(id);
            if (contato == null)
            {
                throw new Exception("Contato não existe");
            }
            await _contatoRepository.DeleteAsync(id);
            return null;
        }

        public async Task<ContatoDto> GetById(Guid id)
        {
            var contato = await _contatoRepository.GetByIdWithIncludeAgenda(id);
            if (contato == null)
                throw new Exception("Contato não existe");

            return _mapper.Map<ContatoDto>(contato);
        }

        public async Task<List<ContatoDto>> GetAllAsync()
        {
            var contatos = await _contatoRepository.GetWithIncludeAgenda();
            var retorno = _mapper.Map<List<ContatoDto>>(contatos);

            return (retorno);
        }
        //public async Task<List<ContatoDto>> GetAllAsync()
        //{
        //    var contatos = await _contatoRepository.GetWithIncludeAgenda();
        //    var retorno = contatos.Select(x =>
        //    {
        //        var contatoDto = _mapper.Map<ContatoDto>(x);
        //        contatoDto.AgendaDto = _mapper.Map<AgendaBookDto>(x.Agenda);
        //        return contatoDto;
        //    }).ToList();
        //    return retorno;
        //}
    }
}
