﻿using evoWatch.Database.Models;
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

        public async Task RemoveUserAsync(RemoveUserDTO requestUser)
        {
            User? dbUser = await _userRepository.GetUserByIdAsync(requestUser.Id);
            if (dbUser == null)
                throw new Exception("The user with the specified ID wasn't found");

            if (!_hashService.VerifyPassword(requestUser.Password, dbUser.PasswordHash, dbUser.PasswordSalt))
                throw new Exception("Wrong password");

            await _userRepository.RemoveUserAsync(dbUser);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}
