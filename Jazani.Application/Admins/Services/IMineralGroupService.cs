using Jazani.Application.Admins.Dtos.MineralGroups;
using Jazani.Application.Admins.Dtos.PendingTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Services
{
    public interface IMineralGroupService
    {
        Task<IReadOnlyList<MineralGroupDto>> FindAllAsync();
        Task<MineralGroupDto> FindByIdAsync(int id);
        Task<MineralGroupDto> CreateAsync(MineralGroupSaveDto mineralGroupSaveDto);
        Task<MineralGroupDto> EditAsync(int id, MineralGroupSaveDto mineralGroupSaveDto);
        Task<MineralGroupDto> DisabledAsync(int id);
    }
}
