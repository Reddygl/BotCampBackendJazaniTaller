using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generales.Dtos.InvestmentTypes;
using Jazani.Application.Generales.Dtos.MeasureUnits;
using Jazani.Application.Generales.Dtos.Periodtypes;
using Jazani.Domain.Generales.Moldels;
using Jazani.Domain.Generales.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generales.Services.Implementations
{
    public class MeasureUnitService : IMeasureUnitService
    {
        private readonly IMeasureUnitRepository _measureUnitRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MeasureUnitService> _logger;

        public MeasureUnitService(ILogger<MeasureUnitService> logger, IMeasureUnitRepository measureUnitRepository, IMapper mapper)
        {
            _measureUnitRepository = measureUnitRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<MeasureUnitDto> CreateAsync(MeasureUnitSaveDto measureUnitSaveDto)
        {
            MeasureUnit measureUnit = _mapper.Map<MeasureUnit>(measureUnitSaveDto);
            measureUnit.RegistrationDate = DateTime.Now;
            measureUnit.State = true;
            await _measureUnitRepository.SaveAsync(measureUnit);
            return _mapper.Map<MeasureUnitDto>(measureUnit);
        }

        public async Task<MeasureUnitDto> DisabledAsync(int id)
        {
            MeasureUnit measureUnit = await _measureUnitRepository.FindByIdAsync(id);
            if (measureUnit is null) throw MeasureUnitNotFound(id);
            measureUnit.State = false;
            await _measureUnitRepository.SaveAsync(measureUnit);
            return _mapper.Map<MeasureUnitDto>(measureUnit);
        }

        public async Task<MeasureUnitDto> EditAsync(int id, MeasureUnitSaveDto measureUnitSaveDto)
        {
            MeasureUnit? measureUnit = await _measureUnitRepository.FindByIdAsync(id);
            if (measureUnit is null) throw MeasureUnitNotFound(id);
            _mapper.Map<MeasureUnitSaveDto, MeasureUnit>(measureUnitSaveDto, measureUnit);
            await _measureUnitRepository.SaveAsync(measureUnit);
            return _mapper.Map<MeasureUnitDto>(measureUnit);
        }

        public async Task<IReadOnlyList<MeasureUnitDto>> FindAllAsync()
        {
            IReadOnlyList<MeasureUnit> measureUnits = await _measureUnitRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<MeasureUnitDto>>(measureUnits);
        }

        public async Task<MeasureUnitDto> FindByIdAsync(int id)
        {
            MeasureUnit? measureUnit = await _measureUnitRepository.FindByIdAsync(id);

            if (measureUnit is null)
            {
                _logger.LogWarning("Measure Unit no encontrado para el id: " + id);
                throw MeasureUnitNotFound(id);
            }

            _logger.LogInformation("Measure Unit {name}", measureUnit.Name);

            return _mapper.Map<MeasureUnitDto>(measureUnit);
        }
        private NotFoundCoreException MeasureUnitNotFound(int id)
        {
            return new NotFoundCoreException("Measure Unit no encontrado para el id: " + id);
        }
    }
}
