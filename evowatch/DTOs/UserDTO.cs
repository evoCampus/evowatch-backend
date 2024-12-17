using evoWatch.Database.Models;

namespace evoWatch.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string NormalName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Nickname { get; set; }
        public string ImageUrl { get; set; }
        
        public static UserDTO CreateFromUserDocument(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                NormalName = user.NormalName,
                Email = user.Email,
                IsActive = user.IsActive,
                Nickname = user.Nickname,
                ImageUrl = user.ImageUrl
            };
        }
    }

}
