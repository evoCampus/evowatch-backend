using evoWatch.Database.Models;
using evoWatch.Models.DTOs;

namespace evoWatch.Services
{
    public interface IUserService
    {
        Task AddUserAsync(UserDTO user);
        Task<List<User>> GetUsersAsync();
    }
}
