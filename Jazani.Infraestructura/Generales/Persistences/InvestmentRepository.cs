using Jazani.Core.Paginations;
using Jazani.Domain.Cores.Paginations;
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
        private readonly IPaginator<Investment> _paginator;
        public InvestmentRepository(ApplicationDbContext dbContext, IPaginator<Investment> paginator) : base(dbContext)
        {
            _dbContext = dbContext;
            _paginator = paginator;
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

        public async Task<ResponsePagination<Investment>> PaginatedSearch(RequestPagination<Investment> request)
        {
            var filter = request.Filter;

            var query = _dbContext.Set<Investment>().AsQueryable();

            if (filter is not null)
            {
                query = query
                    .Where(x =>
                        (string.IsNullOrWhiteSpace(filter.Description) || x.Description.ToUpper().Contains(filter.Description.ToUpper()))
                    );
            }


            query = query.OrderByDescending(x => x.Id);


            return await _paginator.Paginate(query, request);
        }
    }
}
