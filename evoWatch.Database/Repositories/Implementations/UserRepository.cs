using evoWatch.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace evoWatch.Database.Repositories.Implementations
{
    internal class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext databaseContext) 
        {
            _databaseContext = databaseContext;
        }

        public async Task<User> AddUserAsync(User user)
        {
            var result = await _databaseContext.Users.AddAsync(user);
            await _databaseContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        { 
            return await _databaseContext.Users.FindAsync(id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _databaseContext.Users.SingleOrDefaultAsync(user => user.Email == email);
        }

        public async Task<bool> RemoveUserAsync(User user)
        {
            try
            {
                _databaseContext.Users.Remove(user);
            }
            catch (InvalidOperationException)
            {
                return false;
            }

            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<User> ModifyUserAsync(User modifiedUser)
        {
            var result = _databaseContext.Update(modifiedUser);
            await _databaseContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _databaseContext.Users.ToListAsync();
        }
    }
}
