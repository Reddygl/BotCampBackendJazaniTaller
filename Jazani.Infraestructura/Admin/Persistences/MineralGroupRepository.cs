using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infraestructura.Cores.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Infraestructura.Admin.Persistences
{
    public class MineralGroupRepository : IMineralGroupRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public MineralGroupRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<MineralGroup>> FindAllAsync()
        {
            return await _dbContext.MineralGroups.ToListAsync();
        }
        public async Task<MineralGroup?> FindByIdAsync(int id)
        {
            return await _dbContext.MineralGroups.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MineralGroup> SaveAsync(MineralGroup mineralGroup)
        {
            EntityState state = _dbContext.Entry(mineralGroup).State;
            _ = state switch
            {
                EntityState.Detached => _dbContext.MineralGroups.Add(mineralGroup),
                EntityState.Modified => _dbContext.MineralGroups.Update(mineralGroup),
            };

            await _dbContext.SaveChangesAsync();

            return mineralGroup;
        }
    }
}
