using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evoWatch.Database.Models;

namespace evoWatch.Database.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<User?> GetUserByIdAsync(Guid Id);
        Task<User?> GetUserByEmailAsync(string Email);
        Task<User> RemoveUserAsync(User user);
        Task<User> ModifyUserAsync(User user, User modifiedUser);
        Task<List<User>> GetUsersAsync();
    }
}
