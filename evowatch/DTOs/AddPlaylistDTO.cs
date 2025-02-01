using evoWatch.Database.Models;

namespace evoWatch.DTOs
{
    public class AddPlaylistDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Public { get; set; }
        public Guid UserId { get; set; }
    }
}