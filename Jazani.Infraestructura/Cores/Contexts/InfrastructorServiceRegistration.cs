using Jazani.Domain.Admins.Repositories;
using Jazani.Infraestructura.Admin.Persistences;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Infraestructura.Cores.Contexts
{
    public static class InfrastructorServiceRegistration
    {
        public static IServiceCollection addInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });
            services.AddTransient<IPendingTypeRepository, PendingTypeRepository>();
            services.AddTransient<IMineralGroupRepository, MineralGroupRepository>();
            return services;

        }
    }
}
