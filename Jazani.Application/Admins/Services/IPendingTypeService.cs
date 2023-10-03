using Jazani.Application.Admins.Dtos.PendingTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Services
{
    public interface IPendingTypeService
    {
        Task<IReadOnlyList<PendingTypeDto>> FindAllAsync();
        Task<PendingTypeDto> FindByIdAsync(int id);
        Task<PendingTypeDto> CreateAsync(PendingTypeSaveDto pendingTypeSaveDto);
        Task<PendingTypeDto> EditAsync(int id, PendingTypeSaveDto pendingTypeSaveDto);
        Task<PendingTypeDto> DisabledAsync(int id);
    }
}
