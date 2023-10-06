using Jazani.Domain.Generales.Moldels;
using Jazani.Domain.Generales.Repositories;
using Jazani.Infraestructura.Cores.Contexts;
using Jazani.Infraestructura.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infraestructura.Generales.Persistences
{
    public class MiningConcessionHolderRepository : CrudRepository<MiningConcessionHolder, int>, IMiningConcessionHolderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public MiningConcessionHolderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IReadOnlyList<MiningConcessionHolder>> FindAllAsync()
        {
            return await _dbContext.Set<MiningConcessionHolder>().Include(t => t.MiningConcession).AsNoTracking().ToListAsync();
        }
        public override async Task<MiningConcessionHolder?> FindByIdAndKeyAsync(int id, int key)
        {
            return await _dbContext.Set<MiningConcessionHolder>().Include(t => t.MiningConcession).FirstOrDefaultAsync(t => t.MiningConcessionId == id && t.HolderId == key);
        }
    }
}
