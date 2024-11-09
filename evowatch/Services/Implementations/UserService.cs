using evoWatch.Database.Models;
using evoWatch.Database.Repositories;
using evoWatch.DTOs;
using evoWatch.Exceptions;
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
            return await _userRepository.GetUserByIdAsync(Id) ?? throw new UserNotFoundException();
        }
        public async Task<User?> GetUserByEmailAsync(string Email)
        {
            return await _userRepository.GetUserByEmailAsync(Email);
        }

        public async Task RemoveUserAsync(Guid id, string password)
        {
            User? dbUser = await _userRepository.GetUserByIdAsync(id);
            if (dbUser == null)
                throw new UserNotFoundException();

            if (!_hashService.VerifyPassword(password, dbUser.PasswordHash, dbUser.PasswordSalt))
                throw new WrongPasswordException();

            await _userRepository.RemoveUserAsync(dbUser);
        }

        public async Task ModifyUserAsync(Guid id, ModifyUserDTO user)
        {
            var result = new ModifyUser()
            {
                Email = user.Email,
                NormalName = user.NormalName,
                Nickname = user.Nickname,
                ImageUrl = user.ImageUrl,
                PasswordHash = null,
                PasswordSalt = null
            };

            if (user.Password != null)
            {
                HashResult hashResult = _hashService.HashPassword(user.Password);
                result.PasswordHash = hashResult.Hash;
                result.PasswordSalt = hashResult.Salt;
            }

            await _userRepository.ModifyUserAsync(id, result);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}
