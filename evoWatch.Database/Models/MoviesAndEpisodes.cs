using System.Text.Json;

namespace evoWatch.Database.Models
{
    public class MoviesAndEpisodes
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public  string Genre { get; set; }
        public  DateTime ReleaseYear { get; set; }
        public string Description { get; set; }
        public  string Language { get; set; }
        public  string Awards { get; set; }

        public Guid SeasonId { get; set; } //FK to Season
        public virtual Seasons Season { get; set; } //navigation property to Season

        public Guid ProductionCompanyId { get; set; } // <-- FK to ProductionCompany
        public virtual ProductionCompany ProductionCompany { get; set; }
   

        public ICollection<PersonMoviesConnectionTable> PersonMoviesConnections { get; set; }
        public ICollection<Characters> Characters { get; set; }
    }
}
