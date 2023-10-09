using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generales.Dtos.Periodtypes;
using Jazani.Domain.Generales.Moldels;
using Jazani.Domain.Generales.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Generales.Services.Implementations
{
    public class PeriodtypeService : IPeriodtypeService
    {
        private readonly IPeriodtypeRepository _periodtypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PeriodtypeService> _logger;

        public PeriodtypeService(ILogger<PeriodtypeService> logger, IPeriodtypeRepository periodtypeRepository, IMapper mapper)
        {
            _periodtypeRepository = periodtypeRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<PeriodtypeDto> CreateAsync(PeriodtypeSaveDto periodtypeSaveDto)
        {
            Periodtype periodtype = _mapper.Map<Periodtype>(periodtypeSaveDto);
            periodtype.RegistrationDate = DateTime.Now;
            periodtype.State = true;
            await _periodtypeRepository.SaveAsync(periodtype);
            return _mapper.Map<PeriodtypeDto>(periodtype);
        }

        public async Task<PeriodtypeDto> DisabledAsync(int id)
        {
            Periodtype periodtype = await _periodtypeRepository.FindByIdAsync(id);
            if (periodtype is null) throw PeriodtypeNotFound(id);
            periodtype.State = false;
            await _periodtypeRepository.SaveAsync(periodtype);
            return _mapper.Map<PeriodtypeDto>(periodtype);
        }

        public async Task<PeriodtypeDto> EditAsync(int id, PeriodtypeSaveDto periodtypeSaveDto)
        {
            Periodtype? periodtype = await _periodtypeRepository.FindByIdAsync(id);
            if (periodtype is null) throw PeriodtypeNotFound(id);
            _mapper.Map<PeriodtypeSaveDto, Periodtype>(periodtypeSaveDto, periodtype);
            await _periodtypeRepository.SaveAsync(periodtype);
            return _mapper.Map<PeriodtypeDto>(periodtype);
        }

        public async Task<IReadOnlyList<PeriodtypeDto>> FindAllAsync()
        {
            IReadOnlyList<Periodtype> perioTypes = await _periodtypeRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<PeriodtypeDto>>(perioTypes);
        }

        public async Task<PeriodtypeDto> FindByIdAsync(int id)
        {
            Periodtype? periodtype = await _periodtypeRepository.FindByIdAsync(id);

            if (periodtype is null)
            {
                _logger.LogWarning("Period type no encontrado para el id: " + id);
                throw PeriodtypeNotFound(id);
            }

            _logger.LogInformation("Period type {name}", periodtype.Name);

            return _mapper.Map<PeriodtypeDto>(periodtype);
        }

        private NotFoundCoreException PeriodtypeNotFound(int id)
        {
            return new NotFoundCoreException("Period Type no encontrado para el id: " + id);
        }
    }
}
