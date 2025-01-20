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
            services.AddScoped<IFileSystemService, FileSystemService>();
            services.AddScoped<IProfilePictureService, ProfilePictureService>(services =>
            {
                var fileSystemService = services.GetRequiredService<IFileSystemService>();
                fileSystemService.Initialize("profilePictures");
                return new ProfilePictureService(fileSystemService);
            });
            services.AddScoped<ISeriesService, SeriesService>();

            return services;
        }
    }
}
