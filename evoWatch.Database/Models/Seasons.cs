using System.Text.Json;

namespace evoWatch.Database.Models
{
    public class Seasons
    {
        public Guid Id { get; set; }
        public required DateTime ReleaseYear { get; set; }
        public required int SeasonCount { get; set; }
        public required int Episodes { get; set; }

       
        public Guid SeriesId { get; set; }  // FK to Series
        public virtual Series Series { get; set; }  // Navigation property to Series

        public virtual ICollection<MoviesAndEpisodes> MoviesAndEpisodesList { get; set; }
    }
}
