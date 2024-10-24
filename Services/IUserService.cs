using evoWatch.Database.Models;
using evoWatch.DTOs;

namespace evoWatch.Services
{
    public interface IUserService
    {
        Task AddUserAsync(UserDTO user);
        Task<List<User>> GetUsersAsync();
    }
}
