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
        Task<User?> GetUserByIdAsync(Guid id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<bool> RemoveUserAsync(User user);
        Task<User> ModifyUserAsync(User modifiedUser);
        Task<IEnumerable<User>> GetUsersAsync();
    }
}
