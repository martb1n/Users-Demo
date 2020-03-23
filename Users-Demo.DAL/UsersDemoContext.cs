using Microsoft.EntityFrameworkCore;
using Users_Demo.DAL.Models;

namespace Users_Demo.DAL
{
    public class UsersDemoContext : DbContext
    {
        public UsersDemoContext(DbContextOptions<UsersDemoContext> options) : 
            base(options) 
        { 
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<University> University { get; set; }
    }
}
