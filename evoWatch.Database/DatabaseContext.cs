using evoWatch.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace evoWatch.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

  
    }

}
