using Microsoft.EntityFrameworkCore;

namespace Users_Demo.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
    }
}
