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

        public async Task AddUserAsync(User user)
        {
            _databaseContext.Users.Add(user);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid Id)
        { 
            return await _databaseContext.Users.FindAsync(Id);
        }

        public async Task<User?> GetUserByEmailAsync(string Email)
        {
            return await _databaseContext.Users.SingleAsync(c => c.Email == Email);
        }

        public async Task RemoveUserAsync(Guid Id)
        {
            var result = new User() { Id = Id };
            _databaseContext.Users.Attach(result);
            _databaseContext.Users.Remove(result);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _databaseContext.Users.ToListAsync();
        }
    }
}
