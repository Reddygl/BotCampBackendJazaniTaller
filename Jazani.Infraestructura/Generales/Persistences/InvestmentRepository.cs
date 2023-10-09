using Jazani.Domain.Generales.Moldels;
using Jazani.Domain.Generales.Repositories;
using Jazani.Infraestructura.Cores.Contexts;
using Jazani.Infraestructura.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infraestructura.Generales.Persistences
{
    public class InvestmentRepository : CrudRepository<Investment, int>, IInvestmentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public InvestmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public override async Task<IReadOnlyList<Investment>> FindAllAsync()
        {
            return await _dbContext.Set<Investment>()
                        .Include(t => t.Holder)
                        .Include(t => t.MiningConcession)
                        .Include(t => t.MeasureUnit)
                        .Include(t => t.Periodtype)
                        .Include(t => t.InvestmentConcept)
                        .Include(t => t.InvestmentType)
                        .AsNoTracking().ToListAsync();
        }
        public override async Task<Investment?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<Investment>()
                        .Include(t => t.Holder)
                        .Include(t => t.MiningConcession)
                        .Include(t => t.MeasureUnit)
                        .Include(t => t.Periodtype)
                        .Include(t => t.InvestmentConcept)
                        .Include(t => t.InvestmentType)
                        .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
