using System.ComponentModel.DataAnnotations;

namespace evoWatch.Database.Models
{
    public class Episode
    {
        [Key]
        public required Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public required string Title { get; set; }

        [MaxLength(50, ErrorMessage = "Genre cannot be longer than 50 characters.")]
        public  string Genre { get; set; }

        [Range(1900, 2100, ErrorMessage = "ReleaseYear must be between 1900 and 2100.")]
        public  int ReleaseYear { get; set; }

        [MaxLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]      
        public string Description { get; set; }

        [MaxLength(20, ErrorMessage = "Language cannot be longer than 50 characters.")]
        public  string Language { get; set; }

        [MaxLength(50, ErrorMessage = "Award cannot be longer than 50 characters.")]
        public  string Award { get; set; }

        public virtual Season Season { get; set; }

        public virtual ProductionCompany ProductionCompany { get; set; }

        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
    }
}
