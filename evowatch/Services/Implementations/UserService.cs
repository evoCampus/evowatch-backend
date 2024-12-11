using evoWatch.Database.Models;
using evoWatch.Database.Repositories;
using evoWatch.Models;
using evoWatch.Models.DTOs;

namespace evoWatch.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashService _hashService;

        public UserService(IUserRepository userRepository, IHashService hashService)
        {
            _userRepository = userRepository;
            _hashService = hashService;
        }
        public async Task AddUserAsync(UserDTO user)
        {
            HashResult hashResult = _hashService.HashPassword(user.Password);

            var result = new User()
            {   
                Id = Guid.NewGuid(),
                Email = user.Email,
                NormalName = user.NormalName,
                Nickname = user.Nickname,
                ImageUrl = user.ImageUrl,
                PasswordHash = hashResult.Hash,
                PasswordSalt = hashResult.Salt
            };
            await _userRepository.AddUserAsync(result);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}
