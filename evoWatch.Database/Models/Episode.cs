using System.Text.Json;

namespace evoWatch.Database.Models
{
    public class Episode
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public  string Genre { get; set; }
        public  DateTime ReleaseYear { get; set; }
        public string Description { get; set; }
        public  string Language { get; set; }
        public  string Awards { get; set; }

        public Guid SeasonId { get; set; } 
        public virtual Season Seasons { get; set; } 

        public Guid ProductionCompanyId { get; set; }
        public virtual ProductionCompany ProductionCompanies { get; set; }
   

        public ICollection<PersonEpisode> PersonEpisodes { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
