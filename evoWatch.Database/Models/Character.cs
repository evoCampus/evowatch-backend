using System.ComponentModel.DataAnnotations;

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

        public virtual Episode Episode { get; set; }

        public virtual Person Person { get; set; }
    }
}
