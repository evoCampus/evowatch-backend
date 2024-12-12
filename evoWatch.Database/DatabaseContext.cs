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
        public DbSet<PersonEpisode> PeopleMoviesConnections { get; set; }
        public DbSet<ProductionCompany> ProductionCompanies { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Series> Series { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Series>()
               .HasMany(x => x.Seasons)
               .WithOne(x => x.Series)
               .HasForeignKey(x => x.SeriesId);

            modelBuilder.Entity<Season>()
               .HasMany(x => x.Episodes)
               .WithOne(x => x.Seasons)
               .HasForeignKey(x => x.SeasonId);

            modelBuilder.Entity<ProductionCompany>()
                .HasMany(x => x.Episodes)
                .WithOne(x => x.ProductionCompanies)
                .HasForeignKey(x => x.ProductionCompanyId);

            modelBuilder.Entity<Episode>()
               .HasMany(x => x.Characters)
               .WithOne(x => x.Episodes)
               .HasForeignKey(x => x.EpisodesId);

            modelBuilder.Entity<Episode>()
               .HasMany(x => x.PersonEpisodes)
               .WithOne(x => x.Episodes)
               .HasForeignKey(x => x.EpisodesId);

            modelBuilder.Entity<Person>()
               .HasMany(x => x.Characters)
               .WithOne(x => x.People)
               .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<Person>()
              .HasMany(x => x.PeopleEpisodes)
              .WithOne(x => x.People)
              .HasForeignKey(x => x.PersoniD);

            modelBuilder.Entity<PersonEpisode>()
                .HasKey(x => new { x.PersoniD, x.EpisodesId });




        }



        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

       


    }

}
