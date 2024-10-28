using evoWatch.Database.Models;
using evoWatch.DTOs;

namespace evoWatch.Services
{
    public interface IUserService
    {
        Task AddUserAsync(UserDTO user);
        Task<User?> GetUserByIdAsync(Guid Id);
        Task<User?> GetUserByEmailAsync(string Email);
        Task<List<User>> GetUsersAsync();
    }
}
