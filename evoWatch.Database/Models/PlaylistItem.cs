using System.ComponentModel.DataAnnotations;

namespace evoWatch.Database.Models
{
    public class PlaylistItem
    {
        [Key]
        public Guid Id { get; set; }

        public int Order { get; set; }

        public bool Watched { get; set; }

        public virtual Playlist Playlist { get; set; }

        public virtual Episode Episode { get; set; }
    }
}