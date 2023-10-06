using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infraestructura.Cores.Contexts;
using Jazani.Infraestructura.Cores.Persistences;

namespace Jazani.Infraestructura.Admin.Persistences
{
    public class PendingTypeRepository : CrudRepository<PendingType, int>, IPendingTypeRepository
    {
        public PendingTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
