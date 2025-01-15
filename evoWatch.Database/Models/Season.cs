using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace evoWatch.Database.Models
{
    public class Season
    {
        [Key] 
        public Guid Id { get; set; }

        [Required]
        public required int ReleaseYear { get; set; }

        [NotMapped]
        public int EpisodeCount => Episodes?.Count() ?? 0;

        public virtual Series Series { get; set; } 

        public virtual ICollection<Episode> Episodes { get; set; }
    }
}
