using Jazani.Domain.Cores.Repositories;
using Jazani.Domain.Generales.Moldels;

namespace Jazani.Domain.Generales.Repositories
{
    public interface IInvestmentRepository : ICrudRepository<Investment, int>, IPaginatedRepository<Investment>
    {
    }
}
