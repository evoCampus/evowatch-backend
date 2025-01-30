using evoWatch.Database.Models;

namespace evoWatch.DTOs
{
    public class ModifyUserDTO
    {
        public string NormalName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Nickname { get; set; }

        public User ConvertToUserDocument(Guid id, string passwordHash, byte[] passwordSalt)
        {
            return new User
            {
                Id = id,
                NormalName = NormalName,
                Email = Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsActive = IsActive == true,
                Nickname = Nickname,

            };
        }
    }
}
