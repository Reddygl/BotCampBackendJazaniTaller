using Jazani.Domain.Cores.Paginations;
using Jazani.Infraestructura.Cores.Paginations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddTransient(typeof(IPaginator<>), typeof(Paginator<>));
            return services;

        }
    }
}
