using evoWatch.Services;
using evoWatch.Services.Implementations;

namespace evoWatch
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddEvoWatch(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHashService, HashService>();
            services.AddScoped<ISeriesService, SeriesService>();

            return services;
        }
    }
}
