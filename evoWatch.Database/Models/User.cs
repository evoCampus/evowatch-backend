using System.Text.Json;

namespace evoWatch.Database.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public required string NormalName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsActive { get; set; }
        public string Nickname { get; set; }
        public string ImageUrl { get; set; }

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
