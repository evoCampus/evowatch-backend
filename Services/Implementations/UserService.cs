using evoWatch.Database.Models;
using evoWatch.Database.Repositories;
using evoWatch.DTOs;

namespace evoWatch.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task AddUserAsync(UserDTO user)
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
            await _userRepository.AddUserAsync(result);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}
