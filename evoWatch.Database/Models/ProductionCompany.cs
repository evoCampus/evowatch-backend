using System.ComponentModel.DataAnnotations;

namespace evoWatch.Database.Models
{
    public class ProductionCompany
    {
        [Key] 
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public required string Name { get; set; }

        [Required]
        public int FoundationYear { get; set; }

        [MaxLength(50, ErrorMessage = "Country cannot be longer than 50 characters.")]
        public string Country { get; set; }

        [MaxLength(200, ErrorMessage = "Website URL cannot be longer than 200 characters.")]
        [Url(ErrorMessage = "Please provide a valid URL.")]
        public string Website { get; set; }

        public virtual ICollection<Episode> Episodes { get; set; }
    }
}
