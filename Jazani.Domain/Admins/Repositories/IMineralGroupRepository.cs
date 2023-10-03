using Jazani.Domain.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Domain.Admins.Repositories
{
    public interface IMineralGroupRepository
    {
        Task<IReadOnlyList<MineralGroup>> FindAllAsync();
        Task<MineralGroup> FindByIdAsync(int id);
        Task<MineralGroup> SaveAsync(MineralGroup mineralGroup);
    }
}
