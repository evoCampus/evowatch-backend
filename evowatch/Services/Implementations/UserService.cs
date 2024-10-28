using evoWatch.Database.Models;
using evoWatch.Database.Repositories;
using evoWatch.DTOs;
using evoWatch.Models;


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
        public async Task AddUserAsync(AddUserDTO user)
        {
            HashResult hashResult = _hashService.HashPassword(user.Password);

            var result = new User()
            {
                Email = user.Email,
                NormalName = user.NormalName,
                Nickname = user.Nickname,
                ImageUrl = user.ImageUrl,
                PasswordHash = hashResult.Hash,
                PasswordSalt = hashResult.Salt
            };
            await _userRepository.AddUserAsync(result);
        }
        public async Task<User?> GetUserByIdAsync(Guid Id) 
        {
            return await _userRepository.GetUserByIdAsync(Id);
        }
        public async Task<User?> GetUserByEmailAsync(string Email) 
        {
            return await _userRepository.GetUserByEmailAsync(Email);
        }

        public async Task RemoveUserAsync(RemoveUserDTO user)
        {
            await _userRepository.RemoveUserAsync(user.Id); //without verification
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}
