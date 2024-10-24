using evoWatch.Database.Repositories;
using evoWatch.Database.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace evoWatch.Database
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddEvoWatchDatabase(this IServiceCollection services, string? connectionString)
        {
            if(string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUserRepository, UserRepository>();
            
            return services;
        }
    }
}
