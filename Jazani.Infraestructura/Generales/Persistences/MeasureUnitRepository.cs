using Jazani.Domain.Generales.Moldels;
using Jazani.Domain.Generales.Repositories;
using Jazani.Infraestructura.Cores.Contexts;
using Jazani.Infraestructura.Cores.Persistences;

namespace Jazani.Infraestructura.Generales.Persistences
{
    public class MeasureUnitRepository : CrudRepository<MeasureUnit, int>, IMeasureUnitRepository
    {
        public MeasureUnitRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
