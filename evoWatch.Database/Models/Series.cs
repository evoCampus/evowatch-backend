using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace evoWatch.Database.Models
{
    public class Series
    {
        [Key] 
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        [Required] 
        [MaxLength(50, ErrorMessage = "Genre cannot be longer than 50 characters.")]
        public string Genre { get; set; }

         [Range(1900, 2100, ErrorMessage = "ReleaseYear must be between 1900 and 2100.")]
        public  int ReleaseYear { get; set; }

        [Range(1900, 2100, ErrorMessage = "ReleaseYear must be between 1900 and 2100.")]
        public int FinalYear { get; set; }

        [MaxLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]
        public string Description { get; set; }

        [NotMapped]
        public int SeasonsCount => Seasons?.Count() ?? 0;

        public virtual ICollection<Season> Seasons { get; set; }
    }
}
