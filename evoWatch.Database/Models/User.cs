using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace evoWatch.Database.Models
{
    public class User
    {
        [Required]
        [MaxLength(30, ErrorMessage = "NormalName cannot be longer than: 30")]
        public string NormalName { get; set; }

        [Required]
        [MaxLength(32, ErrorMessage = "Email cannot be longer than: 32")]
        public string Email { get; set; }

        [MaxLength(16, ErrorMessage = "Nickname cannot be longer than: 16")]
        public string Nickname { get; set; }

        [MaxLength(2048, ErrorMessage = "ImageUrl cannot be longer than: 2048")]
        public string? ImageUrl { get; set; }

        public Guid Id { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public bool IsActive { get; set; }

        public User()
        {
        }

        public User(string normalName, string email, string passwordHash, byte[] passwordSalt, bool isActive, string nickname, string imageUrl)
        {
            Id = Guid.NewGuid();
            NormalName = normalName;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = new byte[] { 1, 2, 3 };
            IsActive = isActive;
            Nickname = nickname;
            ImageUrl = imageUrl;
        }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
