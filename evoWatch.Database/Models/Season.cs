using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace evoWatch.Database.Models
{
    public class Season
    {
        [Key] 
        public Guid Id { get; set; }

        [Required]
        public required int ReleaseYear { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "SeasonCount must be greater than or equal to 1.")]
        public int SeasonCount { get; set; } 

        [Range(1, int.MaxValue, ErrorMessage = "EpisodeCount must be greater than or equal to 1.")]
        public int EpisodeCount { get; set; }  

        [Required]  
        public Guid SeriesId { get; set; }

        [ForeignKey(nameof(SeriesId))] 
        public virtual Series Series { get; set; } 
        public virtual ICollection<Episode> Episodes { get; set; }
    }
}
