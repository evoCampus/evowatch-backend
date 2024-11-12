using System.Text.Json;

namespace evoWatch.Database.Models
{
    public class PersonMoviesConnectionTable
    {
        public Guid PersoniD { get; set; }
        public Person People { get; set; }



        public Guid MoviesAndEpisodesiD { get; set; }
        public MoviesAndEpisodes MoviesEpisodes { get; set; }
        
    }
}
