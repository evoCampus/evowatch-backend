using evoWatch.Database.Models;
using evoWatch.DTOs;

namespace evoWatch.Services
{
    public interface IUserService
    {
        Task AddUserAsync(AddUserDTO user);
        Task RemoveUserAsync(RemoveUserDTO user);
        Task<User?> GetUserByIdAsync(Guid Id);
        Task<User?> GetUserByEmailAsync(string Email);
        Task<List<User>> GetUsersAsync();
    }
}
