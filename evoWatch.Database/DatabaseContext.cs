using evoWatch.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace evoWatch.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Episode> MoviesAndEpisodes { get; set; }
        public DbSet<Person> People { get; set; }    
        public DbSet<ProductionCompany> ProductionCompanies { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<PlaylistItem> PlaylistItem { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
    }
}
