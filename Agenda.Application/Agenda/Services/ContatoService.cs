using Agenda.Application.Agenda.Dtos;
using Agenda.Domain.Agendas;
using Agenda.Domain.Agendas.Repository;
using AutoMapper;

namespace Agenda.Application.Agenda.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IMapper _mapper;

        public ContatoService(IContatoRepository contatoRepository, IMapper mapper)
        {
            _contatoRepository = contatoRepository;
            _mapper = mapper;
        }

        public async Task<ContatoDto> CreateContatoAsync(ContatoDto dto)
        {
            if (await _contatoRepository.AnyAsync(x => x.Nome == dto.Nome))
                throw new Exception("Já existe este contato cadastrado");
            try
            {
                var contato = _mapper.Map<Contato>(dto);

                await _contatoRepository.AddAsync(contato);              
         
                return _mapper.Map<ContatoDto>(contato);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public async Task<ContatoDto> GetById(Guid id)
        {
            var contato = await _contatoRepository.GetByIdAsync(id);
            if (contato == null)
                throw new Exception("Contato não existe");

            return _mapper.Map<ContatoDto>(contato);
        }

        public async Task<List<ContatoDto>> GetAllAsync()
        {
            var contatos = await _contatoRepository.GetAllAsync(); 

            return _mapper.Map<List<ContatoDto>>(contatos); 
        }
    }
}
