using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Savora.Infrastructure.Persistence.Contexts;

namespace Savora.Infrastructure
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Connection To SQL Server
            services.AddDbContext<SavoraContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });


            // App Entity Repositories

            // Generic Repositories

            return services;
        }
    }
}
