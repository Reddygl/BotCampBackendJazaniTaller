using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generales.Dtos.InvestmentConcepts;
using Jazani.Domain.Generales.Moldels;
using Jazani.Domain.Generales.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Generales.Services.Implementations
{
    public class InvestmentConceptService : IInvestmentConceptService
    {
        private readonly IInvestmentConceptRepository _investmentConceptRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InvestmentConceptService> _logger;

        public InvestmentConceptService(ILogger<InvestmentConceptService> logger, IInvestmentConceptRepository investmentConceptRepository, IMapper mapper)
        {
            _investmentConceptRepository = investmentConceptRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<InvestmentConceptDto> CreateAsync(InvestmentConceptSaveDto investmentConceptSaveDto)
        {
            InvestmentConcept investmentConcept = _mapper.Map<InvestmentConcept>(investmentConceptSaveDto);
            investmentConcept.RegistrationDate = DateTime.Now;
            investmentConcept.State = true;
            await _investmentConceptRepository.SaveAsync(investmentConcept);
            return _mapper.Map<InvestmentConceptDto>(investmentConcept);
        }

        public async Task<InvestmentConceptDto> DisabledAsync(int id)
        {
            InvestmentConcept investmentConcept = await _investmentConceptRepository.FindByIdAsync(id);
            if (investmentConcept is null) throw InvestmentConceptNotFound(id);
            investmentConcept.State = false;
            await _investmentConceptRepository.SaveAsync(investmentConcept);
            return _mapper.Map<InvestmentConceptDto>(investmentConcept);
        }

        public async Task<InvestmentConceptDto> EditAsync(int id, InvestmentConceptSaveDto investmentConceptSaveDto)
        {
            InvestmentConcept? investmentConcept = await _investmentConceptRepository.FindByIdAsync(id);
            if (investmentConcept is null) throw InvestmentConceptNotFound(id);
            _mapper.Map<InvestmentConceptSaveDto, InvestmentConcept>(investmentConceptSaveDto, investmentConcept);
            await _investmentConceptRepository.SaveAsync(investmentConcept);
            return _mapper.Map<InvestmentConceptDto>(investmentConcept);
        }

        public async Task<IReadOnlyList<InvestmentConceptDto>> FindAllAsync()
        {
            IReadOnlyList<InvestmentConcept> investmentConcepts = await _investmentConceptRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<InvestmentConceptDto>>(investmentConcepts);
        }

        public async Task<InvestmentConceptDto> FindByIdAsync(int id)
        {
            InvestmentConcept? investmentConcept = await _investmentConceptRepository.FindByIdAsync(id);

            if (investmentConcept is null)
            {
                _logger.LogWarning("Investment Concept no encontrado para el id: " + id);
                throw InvestmentConceptNotFound(id);
            }

            _logger.LogInformation("Investment Concept {name}", investmentConcept.Name);

            return _mapper.Map<InvestmentConceptDto>(investmentConcept);
        }
        private NotFoundCoreException InvestmentConceptNotFound(int id)
        {
            return new NotFoundCoreException("Investment Concept no encontrado para el id: " + id);
        }
    }
}
