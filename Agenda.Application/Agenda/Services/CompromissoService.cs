using Agenda.Application.Agenda.Dtos;
using Agenda.Domain.Agendas;
using Agenda.Domain.Agendas.Repository;
using AutoMapper;

namespace Agenda.Application.Agenda.Services
{
    public class CompromissoService : ICompromissoService
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly ICompromissoRepository _compromissoRepository;
        private readonly IMapper _mapper;


        public CompromissoService(ICompromissoRepository compromissoRepository, IMapper mapper, IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
            _compromissoRepository = compromissoRepository;
            _mapper = mapper;
        }

        public async Task<CompromissoDto> CreateCompromissoAsync(CompromissoDto dto, Guid id)
        {

            if (await _compromissoRepository.AnyAsync(x => x.HoraDeInicio == dto.HoraDeInicio) && await _compromissoRepository.AnyAsync(x => x.HoraDeTermino == dto.HoraDeTermino))
                throw new Exception("Já existe um compromisso cadastrado neste horário");

            try
            {
                var compromisso = _mapper.Map<Compromisso>(dto);


                var agenda = await _agendaRepository.GetByIdAsync(id);
                compromisso.AgendaId = agenda.Id;
                await _compromissoRepository.AddAsync(compromisso);

                return _mapper.Map<CompromissoDto>(compromisso);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<CompromissoDto> UpdateCompromissoAsync(Guid id)
        {
            var compromisso = await _compromissoRepository.GetByIdAsync(id);
            if (compromisso == null)

            {
                throw new Exception("Compromisso não existe");
            }
            await _compromissoRepository.UpdateAsync(compromisso);
            return _mapper.Map<CompromissoDto>(compromisso);

        }

        public async Task<CompromissoDto> DeleteCompromissoAsync(Guid id)
        {
            var compromisso = await _compromissoRepository.GetByIdAsync(id);
            if (compromisso == null)
            {
                throw new Exception("Compromisso não existe");
            }
            await _compromissoRepository.DeleteAsync(id);
            return null;
        }

        public async Task<CompromissoDto> GetById(Guid id)
        {
            var compromisso = await _compromissoRepository.GetByIdAsync(id);
            if (compromisso == null)
                throw new Exception("Compromisso não existe");

            return _mapper.Map<CompromissoDto>(compromisso);
        }

        public async Task<List<CompromissoDto>> GetAllAsync()
        {
            var compromissos = await _compromissoRepository.GetAllAsync();

            return _mapper.Map<List<CompromissoDto>>(compromissos);
        }
    }
}
