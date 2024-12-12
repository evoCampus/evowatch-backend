using evoWatch.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace evoWatch.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }




        public DbSet<Person> People { get; set; }

        public DbSet<MoviesAndEpisodes> MoviesAndEpisodes { get; set; }

        public DbSet<PersonMoviesConnectionTable> PeopleMoviesConnection {  get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // rRelationship between MoviesAndEpisodes and ProductionCompany
            modelBuilder.Entity<MoviesAndEpisodes>()
                .HasOne(m => m.ProductionCompany)
                .WithMany(pc => pc.MoviesAndEpisodesList) // <-- Collection in ProductionCompany
                .HasForeignKey(m => m.ProductionCompanyId); // FK key in MoviesAndEpisodes

            // one-to-many relationship between Series and Seasons

            modelBuilder.Entity<Seasons>()
                .HasOne(s => s.Series)
                .WithMany(series => series.Seasons)
                .HasForeignKey(s => s.SeriesId);

            // Configure one-to-many relationship between Seasons and MoviesAndEpisodes
            modelBuilder.Entity<MoviesAndEpisodes>()
                .HasOne(m => m.Season)
                .WithMany(s => s.MoviesAndEpisodesList)
                .HasForeignKey(m => m.SeasonId);

            // Configure composite key for the connection table
            modelBuilder.Entity<PersonMoviesConnectionTable>()
                .HasKey(pm => new { pm.PersoniD, pm.MoviesAndEpisodesiD });

            // Configure relationship from PersonMoviesConnectionTable to Person
            modelBuilder.Entity<PersonMoviesConnectionTable>()
                .HasOne(pm => pm.People)
                .WithMany(p => p.PersonMoviesConnections)
                .HasForeignKey(pm => pm.PersoniD);

            // Configure relationship from PersonMoviesConnectionTable to MoviesAndEpisodes
            modelBuilder.Entity<PersonMoviesConnectionTable>()
                .HasOne(pm => pm.MoviesEpisodes)
                .WithMany(m => m.PersonMoviesConnections)
                .HasForeignKey(pm => pm.MoviesAndEpisodesiD);

            // Define the composite primary key for the Character table
            modelBuilder.Entity<Characters>()
                .HasKey(c => new { c.PersonId, c.MoviesAndEpisodesId });

            // Define the relationship between Person and Character (junction table)
            modelBuilder.Entity<Characters>()
                .HasOne(c => c.Person)
                .WithMany(p => p.Characters)  // <-- Now 'Characters' exists in Person class
                .HasForeignKey(c => c.PersonId); // Foreign key to Person

            // Define the relationship between MoviesAndEpisodes and Character (junction table)
            modelBuilder.Entity<Characters>()
                .HasOne(c => c.MoviesAndEpisodes)
                .WithMany(m => m.Characters)  // <-- Now 'Characters' exists in MoviesAndEpisodes class
                .HasForeignKey(c => c.MoviesAndEpisodesId); // Foreign key to MoviesAndEpisodes

        }



        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

       


    }

}
