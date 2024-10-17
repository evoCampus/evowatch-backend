using evoWatch.DatabaseRelated;
using evoWatch.Models;
using evoWatch.Models.DTO;

namespace evoWatch.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _context;

        public UserService(DatabaseContext context)
        {
               _context = context;
        }
        public void addUser(UserDTO user)
        {
            var result = new User()
            {
                Email = user.Email,
                NormalName = user.NormalName,
                Nickname = user.Nickname,
                ImageUrl = user.ImageUrl,
                PasswordHash = user.Password,
                PasswordSalt = new byte[] { 1, 2, 3 }
            };
            _context.Users.Add(result);
            _context.SaveChanges();
        }

        public List<User> getUsers()
        {
            var result = _context.Users.ToList();

            return result;
        }
    }
}
