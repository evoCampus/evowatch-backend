using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace evoWatch.Database.Models
{
    public class Person
    {

        [Key] 
        public required Guid Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public required string Name { get; set; }

        [Range(0, 150, ErrorMessage = "Age must be between 0 and 150.")]
        public int Age { get; set; }

        [MaxLength(50, ErrorMessage = "Role cannot be longer than 50 characters.")]
        public string Role { get; set; }

        [MaxLength(500, ErrorMessage = "Awards cannot be longer than 500 characters.")]
        public string Awards { get; set; }

        [MaxLength(10, ErrorMessage = "Gender cannot be longer than 10 characters.")]
        public string Gender { get; set; }

        [InverseProperty(nameof(PersonEpisode.People))]
        public ICollection<PersonEpisode> PeopleEpisodes { get; set; }

        [InverseProperty(nameof(Character.Person))]
        public ICollection<Character> Characters { get; set; }

    }
}
