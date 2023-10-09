using Jazani.Domain.Generales.Moldels;
using Jazani.Domain.Generales.Repositories;
using Jazani.Infraestructura.Cores.Contexts;
using Jazani.Infraestructura.Cores.Persistences;

namespace Jazani.Infraestructura.Generales.Persistences
{
    public class PeriodtypeRepository : CrudRepository<Periodtype, int>, IPeriodtypeRepository
    {
        public PeriodtypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
