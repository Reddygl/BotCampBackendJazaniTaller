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
    public class PendingTypeRepository : IPendingTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public PendingTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<PendingType>> FindAllAsync()
        {
            return await _dbContext.PendingTypes.ToListAsync();
        }
        public async Task<PendingType?> FindByIdAsync(int id)
        {
            return await _dbContext.PendingTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PendingType> SaveAsync(PendingType pendingType)
        {
            EntityState state = _dbContext.Entry(pendingType).State;
            _ = state switch
            {
                EntityState.Detached => _dbContext.PendingTypes.Add(pendingType),
                EntityState.Modified => _dbContext.PendingTypes.Update(pendingType),
            };

            await _dbContext.SaveChangesAsync();

            return pendingType;
        }
    }
}
