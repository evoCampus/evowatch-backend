using System.Text.Json;

namespace evoWatch.Database.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required string Role { get; set; }
        public required string Awards { get; set; }
        public required string Gender { get; set; }

    }
}
