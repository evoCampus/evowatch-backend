using System.Text.Json;

namespace evoWatch.Database.Models
{
    public class Series
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Genre { get; set; }
        public required DateTime ReleaseYear { get; set; }
        public  DateTime FinalYear { get; set; }
        public string Description { get; set; }
        
        
        public virtual ICollection<Season> Seasons { get; set; }

    }
}
