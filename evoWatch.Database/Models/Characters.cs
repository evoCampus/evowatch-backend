using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoWatch.Database.Models
{
    public class Characters
    {
        public required Guid PersonId { get; set; }
        public Person Person { get; set; }

        public string MovieCharacterName { get; set; }
        public string Role { get; set; }
        public string NickName { get; set; }

        public required Guid MoviesAndEpisodesId { get; set; }
        public MoviesAndEpisodes MoviesAndEpisodes { get; set; }

    }
}
