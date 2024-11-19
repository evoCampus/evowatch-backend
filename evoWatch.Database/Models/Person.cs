using System.Text.Json;

namespace evoWatch.Database.Models
{
    public class Person
    {
        
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
        public  string Role { get; set; }
        public string Awards { get; set; }
        public  string Gender { get; set; }

        public ICollection<PersonEpisode> PeopleEpisodes { get; set; }
        public ICollection<Character> Characters { get; set; }

    }
}
