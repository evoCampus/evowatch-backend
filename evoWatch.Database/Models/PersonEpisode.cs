using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace evoWatch.Database.Models
{
    public class PersonEpisode
    {
        [Key] 
        public Guid Id { get; set; }

        [Required] 
        public Guid PersoniD { get; set; }

        [ForeignKey(nameof(PersoniD))] 
        public Person People { get; set; }

        [Required] 
        public Guid EpisodesId { get; set; }

        [ForeignKey(nameof(EpisodesId))]
        public Episode Episodes { get; set; }

    }
}
