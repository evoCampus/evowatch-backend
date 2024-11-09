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

        public async Task RemoveUserAsync(User user)
        {
            _databaseContext.Users.Remove(user);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task ModifyUserAsync(User user, ModifyUser modifiedUser)
        {
            if(modifiedUser.Email != null) user.Email = modifiedUser.Email;
            if(modifiedUser.NormalName != null) user.NormalName = modifiedUser.NormalName;
            if(modifiedUser.Nickname != null) user.Nickname = modifiedUser.Nickname;
            if(modifiedUser.ImageUrl != null) user.ImageUrl = modifiedUser.ImageUrl;
            if(modifiedUser.PasswordHash != null) user.PasswordHash = modifiedUser.PasswordHash;
            if(modifiedUser.PasswordSalt != null) user.PasswordSalt = modifiedUser.PasswordSalt;
            
            _databaseContext.SaveChanges();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _databaseContext.Users.ToListAsync();
        }
    }
}
