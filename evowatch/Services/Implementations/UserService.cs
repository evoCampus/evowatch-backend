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

        public async Task ModifyUserAsync(Guid id, ModifyUserDTO modifiedUser)
        {
            User user = await _userRepository.GetUserByIdAsync(id) ?? throw new UserNotFoundException();

            if(modifiedUser.Email != null) user.Email = modifiedUser.Email;
            if(modifiedUser.NormalName != null) user.NormalName = modifiedUser.NormalName;
            if(modifiedUser.Nickname != null) user.Nickname = modifiedUser.Nickname;
            if(modifiedUser.ImageUrl != null) user.ImageUrl = modifiedUser.ImageUrl;
            if (modifiedUser.Password != null)
            {
                HashResult hashResult = _hashService.HashPassword(modifiedUser.Password);
                user.PasswordHash = hashResult.Hash;
                user.PasswordSalt = hashResult.Salt;
            }

            await _userRepository.ModifyUserAsync(user);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}
