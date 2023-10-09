using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generales.Dtos.Holders;
using Jazani.Application.Generales.Dtos.InvestmentConcepts;
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
    public class HolderService : IHolderService
    {
        private readonly IHolderRepository _holderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<HolderService> _logger;

        public HolderService(ILogger<HolderService> logger, IHolderRepository holderRepository, IMapper mapper)
        {
            _holderRepository = holderRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public Task<HolderDto> CreateAsync(HolderSaveDto investmentSaveDto)
        {
            throw new NotImplementedException();
        }

        public Task<HolderDto> DisabledAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HolderDto> EditAsync(int id, HolderSaveDto investmentSaveDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<HolderDto>> FindAllAsync()
        {
            IReadOnlyList<Holder> holders = await _holderRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<HolderDto>>(holders);
        }

        public async Task<HolderDto> FindByIdAsync(int id)
        {
            Holder? holder = await _holderRepository.FindByIdAsync(id);

            if (holder is null)
            {
                _logger.LogWarning("Holder no encontrado para el id: " + id);
                throw HolderNotFound(id);
            }

            _logger.LogInformation("Holder {name}", holder.Name);

            return _mapper.Map<HolderDto>(holder);
        }
        private NotFoundCoreException HolderNotFound(int id)
        {
            return new NotFoundCoreException("Holder no encontrado para el id: " + id);
        }
    }
}
