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
        Task AddUserAsync(User user);
        Task<User?> GetUserByIdAsync(Guid Id);
        Task<User?> GetUserByEmailAsync(string Email);
        Task RemoveUserAsync(User user);
        Task ModifyUserAsync(User user);
        Task<List<User>> GetUsersAsync();
    }
}
