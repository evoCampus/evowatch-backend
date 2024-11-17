using System.Reflection;
using evoWatch.Services;
using evoWatch.Services.Implementations;

namespace evoWatch.Database
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddEvoWatch(this IServiceCollection services)
        {
            // Add services to the container.

            services.AddControllers();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHashService, HashService>();

            return services;
        }
    }
}
