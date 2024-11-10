using evoWatch.Database.Models;
using evoWatch.DTOs;

namespace evoWatch.Services
{
    public interface IUserService
    {
        Task AddUserAsync(AddUserDTO user);
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> GetUserByEmailAsync(string email);
        Task RemoveUserAsync(Guid id, string password);
        Task ModifyUserAsync(Guid id, ModifyUserDTO user);
        Task<List<User>> GetUsersAsync();
    }
}
