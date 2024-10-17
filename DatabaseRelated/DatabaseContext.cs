using evoWatch.Models;
using Microsoft.EntityFrameworkCore;

namespace evoWatch.DatabaseRelated
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
    }
}
