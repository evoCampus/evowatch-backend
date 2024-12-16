using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoWatch.Database.Models
{
    public class Character
    {
        [Key]
        public Guid Id { get; set; }

        [Required] 
        [MaxLength(30, ErrorMessage = "CharacterName cannot be longer than 30 characters.")]
        public string CharacterName { get; set; }

        [Required] 
        [MaxLength(20, ErrorMessage = "Role cannot be longer than 20 characters.")]
        public string Role { get; set; }

        [MaxLength(30, ErrorMessage = "NickName cannot be longer than 30 characters.")]
        public string NickName { get; set; }

        [Required]
        public required Guid EpisodeId { get; set; }

        [ForeignKey(nameof(EpisodeId))]
        public Episode Episode { get; set; }

        [Required]
        public required Guid PersonId { get; set; }

        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; }

    }
}
