using System.Text.Json;

namespace evoWatch.Database.Models
{
    public class Season
    {
        public Guid Id { get; set; }
        public required DateTime ReleaseYear { get; set; }
        public  int SeasonCount { get; set; }
        public  int EpisodeCount { get; set; }
       
        public Guid SeriesId { get; set; } 
        public virtual Series Series { get; set; }  

        public virtual ICollection<Episode> Episodes { get; set; }
    }
}
