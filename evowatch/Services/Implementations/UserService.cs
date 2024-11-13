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
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetUserByIdAsync(id) ?? throw new UserNotFoundException();
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email) ?? throw new UserNotFoundException();
        }

        public async Task RemoveUserAsync(Guid id, string password)
        {
            User dbUser = await _userRepository.GetUserByIdAsync(id) ?? throw new UserNotFoundException();

            if (!_hashService.VerifyPassword(password, dbUser.PasswordHash, dbUser.PasswordSalt))
            {
                throw new WrongPasswordException();
            }

            await _userRepository.RemoveUserAsync(dbUser);
        }

        public async Task ModifyUserAsync(Guid id, ModifyUserDTO userDTO)
        {
            User user = await _userRepository.GetUserByIdAsync(id) ?? throw new UserNotFoundException();

            User modifiedUser = new() {
                Id = user.Id,
                NormalName = userDTO.NormalName ?? user.NormalName,
                Email = userDTO.Email ?? user.Email,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
                IsActive = userDTO.IsActive ?? user.IsActive,
                Nickname = userDTO.Nickname ?? user.Nickname,
                ImageUrl = userDTO.ImageUrl ?? user.ImageUrl
            };

            await _userRepository.ModifyUserAsync(user, modifiedUser);
        }

        public async Task ModifyUserPasswordAsync(Guid id, string password)
        {
            User user = await _userRepository.GetUserByIdAsync(id) ?? throw new UserNotFoundException();

            HashResult hashResult = _hashService.HashPassword(password);

            User modifiedUser = new() {
                Id = user.Id,
                NormalName = user.NormalName,
                Email = user.Email,
                PasswordHash = hashResult.Hash,
                PasswordSalt = hashResult.Salt,
                IsActive = user.IsActive,
                Nickname = user.Nickname,
                ImageUrl = user.ImageUrl
            };

            await _userRepository.ModifyUserAsync(user, modifiedUser);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}
