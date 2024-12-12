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
        private readonly IProfilePictureService _profilePictureService;

        public UserService(IUserRepository userRepository, IHashService hashService,IProfilePictureService profilePictureService)
        {
            _userRepository = userRepository;
            _hashService = hashService;
            _profilePictureService = profilePictureService;
        }
        public async Task<UserDTO> AddUserAsync(AddUserDTO user)
        {
            HashResult hashResult = _hashService.HashPassword(user.Password);

            var result = new User()
            {
                Email = user.Email,
                NormalName = user.NormalName,
                Nickname = user.Nickname,
                ImageUrl = user.ImageUrl,
                PasswordHash = hashResult.Hash,
                PasswordSalt = hashResult.Salt,
                IsActive = true
            };
            var response = await _userRepository.AddUserAsync(result);
            return UserDTO.CreateFromUserDocument(response);
        }
        public async Task<UserDTO> GetUserByIdAsync(Guid id)
        {
            var result = await _userRepository.GetUserByIdAsync(id) ?? throw new UserNotFoundException();
            return UserDTO.CreateFromUserDocument(result);
        }
        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            var result =  await _userRepository.GetUserByEmailAsync(email) ?? throw new UserNotFoundException();
            return UserDTO.CreateFromUserDocument(result);
        }

        public async Task<bool> RemoveUserAsync(Guid id, string password)
        {
            User dbUser = await _userRepository.GetUserByIdAsync(id) ?? throw new UserNotFoundException();

            if (!_hashService.VerifyPassword(password, dbUser.PasswordHash, dbUser.PasswordSalt))
            {
                throw new WrongPasswordException();
            }

            return await _userRepository.RemoveUserAsync(dbUser);
        }

        public async Task<UserDTO> ModifyUserAsync(Guid id, ModifyUserDTO userDTO, string password)
        {
            User user = await _userRepository.GetUserByIdAsync(id) ?? throw new UserNotFoundException();

            User modifiedUser = userDTO.ConvertToUserDocument(id, user.PasswordHash, user.PasswordSalt);;

            if (!_hashService.VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                HashResult hashResult = _hashService.HashPassword(password);
                modifiedUser.PasswordHash = hashResult.Hash;
                modifiedUser.PasswordSalt = hashResult.Salt;
            }

            var result = await _userRepository.ModifyUserAsync(modifiedUser);
            return UserDTO.CreateFromUserDocument(result);
        }

        public async Task<FileStream> GetUserProfilePicture(Guid userId)
        {
            User user = await _userRepository.GetUserByIdAsync(userId) ?? throw new UserNotFoundException();
            Guid imageId = Guid.Parse(user.ImageUrl);
            return await _profilePictureService.GetProfilePictureAsync(imageId);
        }

        public async Task<UserDTO> ModifyUserProfilePictureAsync(Guid id, Stream file)
        {
            User user = await _userRepository.GetUserByIdAsync(id) ?? throw new UserNotFoundException();

            Guid imageId = await _profilePictureService.AddProfilePictureAsync(file);

            user.ImageUrl = imageId.ToString();
            var result = await _userRepository.ModifyUserAsync(user);
            return UserDTO.CreateFromUserDocument(result);

        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var result = await _userRepository.GetUsersAsync();
            return result.Select(user => UserDTO.CreateFromUserDocument(user));
        }
    }
}
