using Microsoft.EntityFrameworkCore;
using userAPI.Model;

namespace userAPI.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Userss> Users { get; set; }
    }
}
