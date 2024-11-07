using System.Text.Json;

namespace evoWatch.Database.Models
{
    public class MoviesAndEpisodes
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Genre { get; set; }
        public required DateTime ReleaseYear { get; set; }
        public string Description { get; set; }
        public required string Language { get; set; }
        public required string Awards { get; set; }

        public virtual Seasons Season { get; set; }

        public virtual ProductionCompany ProductionCompany { get; set; }
    }
}
