using System.Text.Json;

namespace evoWatch.Database.Models
{
    public class Seasons
    {
        public Guid Id { get; set; }
        public required DateTime ReleaseYear { get; set; }
        public required int SeasonCount { get; set; }
        public required int Episodes { get; set; }

        public virtual MoviesAndEpisodes Season { get; set; }
    }
}
