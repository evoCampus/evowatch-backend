using System.ComponentModel.DataAnnotations;

namespace evoWatch.Database.Models
{
    public class Playlist
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }

        [MaxLength(1000, ErrorMessage = "Name cannot be longer than 1000 characters")]
        public string Description { get; set; }

        public bool Public { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<PlaylistItem> Items { get; set; }
    }
}