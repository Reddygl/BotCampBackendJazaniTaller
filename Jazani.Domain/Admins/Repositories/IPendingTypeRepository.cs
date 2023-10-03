using Jazani.Domain.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Domain.Admins.Repositories
{
    public interface IPendingTypeRepository
    {
        Task<IReadOnlyList<PendingType>> FindAllAsync();
        Task<PendingType> FindByIdAsync(int id);
        Task<PendingType> SaveAsync(PendingType pendingType);
    }
}
