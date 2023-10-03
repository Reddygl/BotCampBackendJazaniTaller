using AutoMapper;
using Jazani.Application.Admins.Dtos.PendingTypes;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class PendingTypeService : IPendingTypeService
    {
        private readonly IPendingTypeRepository _pendingTypeRepository;
        private readonly IMapper _mapper;
        public PendingTypeService(IPendingTypeRepository pendingTypeRepository, IMapper mapper)
        {
            _pendingTypeRepository = pendingTypeRepository;
            _mapper = mapper;
        }

        public async Task<PendingTypeDto> CreateAsync(PendingTypeSaveDto pendingTypeSaveDto)
        {
            PendingType pendingType = _mapper.Map<PendingType>(pendingTypeSaveDto);
            pendingType.State = true;
            PendingType officeSaved = await _pendingTypeRepository.SaveAsync(pendingType);
            return _mapper.Map<PendingTypeDto>(officeSaved);
        }

        public async Task<PendingTypeDto> DisabledAsync(int id)
        {
            PendingType pendingType = await _pendingTypeRepository.FindByIdAsync(id);
            pendingType.State = false;
            PendingType officeSaved = await _pendingTypeRepository.SaveAsync(pendingType);
            return _mapper.Map<PendingTypeDto>(officeSaved);
        }

        public async Task<PendingTypeDto> EditAsync(int id, PendingTypeSaveDto pendingTypeSaveDto)
        {
            PendingType pendingType = await _pendingTypeRepository.FindByIdAsync(id);
            _mapper.Map<PendingTypeSaveDto, PendingType>(pendingTypeSaveDto, pendingType);
            PendingType officeSaved = await _pendingTypeRepository.SaveAsync(pendingType);
            return _mapper.Map<PendingTypeDto>(officeSaved);
        }

        public async Task<IReadOnlyList<PendingTypeDto>> FindAllAsync()
        {
            IReadOnlyList<PendingType> offices = await _pendingTypeRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<PendingTypeDto>>(offices);
        }
        public async Task<PendingTypeDto?> FindByIdAsync(int id)
        {

            PendingType? pendingType = await _pendingTypeRepository.FindByIdAsync(id);
            return _mapper.Map<PendingTypeDto>(pendingType);
        }
    }
}
