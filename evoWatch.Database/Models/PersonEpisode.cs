using System.Text.Json;

namespace evoWatch.Database.Models
{
    public class PersonEpisode
    {   
        public Guid Id { get; set; }
        public Guid PersoniD { get; set; }
        public Person People { get; set; }



        public Guid EpisodesId { get; set; }
        public Episode Episodes { get; set; }
        
    }
}
