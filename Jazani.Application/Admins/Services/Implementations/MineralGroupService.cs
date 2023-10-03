using AutoMapper;
using Jazani.Application.Admins.Dtos.MineralGroups;
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
    public class MineralGroupService : IMineralGroupService
    {
        private readonly IMineralGroupRepository _mineralGroupRepository;
        private readonly IMapper _mapper;
        public MineralGroupService(IMineralGroupRepository mineralGroupRepository, IMapper mapper)
        {
            _mineralGroupRepository = mineralGroupRepository;
            _mapper = mapper;
        }

        public async Task<MineralGroupDto> CreateAsync(MineralGroupSaveDto mineralGroupSaveDto)
        {
            MineralGroup mineralGroup = _mapper.Map<MineralGroup>(mineralGroupSaveDto);
            mineralGroup.State = true;
            MineralGroup mineralGroupSaved = await _mineralGroupRepository.SaveAsync(mineralGroup);
            return _mapper.Map<MineralGroupDto>(mineralGroupSaved);
        }

        public async Task<MineralGroupDto> DisabledAsync(int id)
        {
            MineralGroup mineralGroup = await _mineralGroupRepository.FindByIdAsync(id);
            mineralGroup.State = false;
            MineralGroup mineralGroupSaved = await _mineralGroupRepository.SaveAsync(mineralGroup);
            return _mapper.Map<MineralGroupDto>(mineralGroupSaved);
        }

        public async Task<MineralGroupDto> EditAsync(int id, MineralGroupSaveDto mineralGroupSaveDto)
        {
            MineralGroup mineralGroup = await _mineralGroupRepository.FindByIdAsync(id);
            _mapper.Map<MineralGroupSaveDto, MineralGroup>(mineralGroupSaveDto, mineralGroup);
            MineralGroup mineralGroupSaved = await _mineralGroupRepository.SaveAsync(mineralGroup);
            return _mapper.Map<MineralGroupDto>(mineralGroupSaved);
        }

        public async Task<IReadOnlyList<MineralGroupDto>> FindAllAsync()
        {
            IReadOnlyList<MineralGroup> mineralGroups = await _mineralGroupRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<MineralGroupDto>>(mineralGroups);
        }
        public async Task<MineralGroupDto?> FindByIdAsync(int id)
        {

            MineralGroup? mineralGroup = await _mineralGroupRepository.FindByIdAsync(id);
            return _mapper.Map<MineralGroupDto>(mineralGroup);
        }
    }
}
