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
            _databaseContext.Users.Add(user);
            await _databaseContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByIdAsync(Guid Id)
        { 
            return await _databaseContext.Users.FindAsync(Id);
        }

        public async Task<User?> GetUserByEmailAsync(string Email)
        {
            return await _databaseContext.Users.SingleOrDefaultAsync(c => c.Email == Email);
        }

        public async Task<User> RemoveUserAsync(User user)
        {
            _databaseContext.Users.Remove(user);
            await _databaseContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> ModifyUserAsync(User user, User modifiedUser)
        {
            _databaseContext.Entry(user).CurrentValues.SetValues(modifiedUser);
            await _databaseContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _databaseContext.Users.ToListAsync();
        }
    }
}
