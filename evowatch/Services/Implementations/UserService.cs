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
            try {
                return await _userRepository.GetUserByEmailAsync(Email);
            }
            catch (InvalidOperationException) 
            {
                throw new UserNotFoundException();
            }
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

        public async Task ModifyUserAsync(Guid id, ModifyUserDTO modifiedUserData)
        {
            User user = await _userRepository.GetUserByIdAsync(id) ?? throw new UserNotFoundException();

            var modifiedUser = new ModifyUser()
            {
                Email = modifiedUserData.Email,
                NormalName = modifiedUserData.NormalName,
                Nickname = modifiedUserData.Nickname,
                ImageUrl = modifiedUserData.ImageUrl,
                PasswordHash = null,
                PasswordSalt = null
            };

            if (modifiedUserData.Password != null)
            {
                HashResult hashResult = _hashService.HashPassword(modifiedUserData.Password);
                modifiedUser.PasswordHash = hashResult.Hash;
                modifiedUser.PasswordSalt = hashResult.Salt;
            }

            await _userRepository.ModifyUserAsync(user, modifiedUser);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}
