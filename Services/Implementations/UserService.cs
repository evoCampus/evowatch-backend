using evoWatch.DatabaseRelated;
using evoWatch.Models;
using evoWatch.Models.DTO;
using static evoWatch.Models.Hash;

namespace evoWatch.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _context;
        private readonly HashService _hashService;

        public UserService(DatabaseContext context)
        {
               _context = context;
               _hashService = new HashService();
        }
        public void addUser(UserDTO user)
        {
            HashResult hashResult = _hashService.HashPassword(user.Password);

            var result = new User()
            {
                Email = user.Email,
                NormalName = user.NormalName,
                Nickname = user.Nickname,
                ImageUrl = user.ImageUrl,
                PasswordHash = hashResult.hash,
                PasswordSalt = hashResult.salt
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
