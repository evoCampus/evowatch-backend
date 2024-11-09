using System.Text.Json;

namespace evoWatch.Database.Models
{
    public class ModifyUser
    {
        public string? NormalName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? Nickname { get; set; }
        public string? ImageUrl { get; set; }
    }
}
