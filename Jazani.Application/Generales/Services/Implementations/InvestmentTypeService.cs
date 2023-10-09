using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generales.Dtos.Investments;
using Jazani.Application.Generales.Dtos.InvestmentTypes;
using Jazani.Application.Generales.Dtos.MeasureUnits;
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
    public class InvestmentTypeService : IInvestmentTypeService
    {
        private readonly IInvestmentTypeRepository _investmentTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InvestmentTypeService> _logger;

        public InvestmentTypeService(ILogger<InvestmentTypeService> logger, IInvestmentTypeRepository investmentTypeRepository, IMapper mapper)
        {
            _investmentTypeRepository = investmentTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<InvestmentTypeDto> CreateAsync(InvestmentTypeSaveDto investmentTypeSaveDto)
        {
            InvestmentType investmentType = _mapper.Map<InvestmentType>(investmentTypeSaveDto);
            investmentType.RegistrationDate = DateTime.Now;
            investmentType.State = true;
            await _investmentTypeRepository.SaveAsync(investmentType);
            return _mapper.Map<InvestmentTypeDto>(investmentType);
        }

        public async Task<InvestmentTypeDto> DisabledAsync(int id)
        {
            InvestmentType investmentType = await _investmentTypeRepository.FindByIdAsync(id);
            if (investmentType is null) throw InvestmentTypeNotFound(id);
            investmentType.State = false;
            await _investmentTypeRepository.SaveAsync(investmentType);
            return _mapper.Map<InvestmentTypeDto>(investmentType);
        }

        public async Task<InvestmentTypeDto> EditAsync(int id, InvestmentTypeSaveDto investmentTypeSaveDto)
        {
            InvestmentType? investmentType = await _investmentTypeRepository.FindByIdAsync(id);
            if (investmentType is null) throw InvestmentTypeNotFound(id);
            _mapper.Map<InvestmentTypeSaveDto, InvestmentType>(investmentTypeSaveDto, investmentType);
            await _investmentTypeRepository.SaveAsync(investmentType);
            return _mapper.Map<InvestmentTypeDto>(investmentType);
        }

        public async Task<IReadOnlyList<InvestmentTypeDto>> FindAllAsync()
        {
            IReadOnlyList<InvestmentType> investmentTypes = await _investmentTypeRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<InvestmentTypeDto>>(investmentTypes);
        }

        public async Task<InvestmentTypeDto> FindByIdAsync(int id)
        {
            InvestmentType? investmentType = await _investmentTypeRepository.FindByIdAsync(id);

            if (investmentType is null)
            {
                _logger.LogWarning("investment Type no encontrado para el id: " + id);
                throw InvestmentTypeNotFound(id);
            }

            _logger.LogInformation("Investment Type {name}", investmentType.Name);

            return _mapper.Map<InvestmentTypeDto>(investmentType);
        }
        private NotFoundCoreException InvestmentTypeNotFound(int id)
        {
            return new NotFoundCoreException("Investment Type no encontrado para el id: " + id);
        }
    }
}
