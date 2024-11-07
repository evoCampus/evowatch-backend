using System.Text.Json;

namespace evoWatch.Database.Models
{
    internal class PersonMoviesConnectionTable
    {
        public virtual MoviesAndEpisodes Movies { get; set; }
        public virtual Person Person { get; set; }
    }
}
