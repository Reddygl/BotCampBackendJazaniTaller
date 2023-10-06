using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Domain.Generales.Moldels;
using Jazani.Domain.Generales.Repositories;
using Jazani.Infraestructura.Cores.Contexts;
using Jazani.Infraestructura.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infraestructura.Admin.Persistences
{
    public class MineralGroupRepository : CrudRepository<MineralGroup, int>, IMineralGroupRepository
    {
        public MineralGroupRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
