using Jazani.Domain.Admins.Models;
using Jazani.Infraestructura.Admin.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Infraestructura.Cores.Contexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        #region "DbSet"
        public DbSet<PendingType> PendingTypes { get; set; }
        public DbSet<MineralGroup> MineralGroups { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PendingTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MineralGroupConfiguration());
        }
    }
}
