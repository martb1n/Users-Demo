using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Users_Demo.DAL.Models;
using Users_Demo.Repository.Implementation;
using Users_Demo.Services.Interface;

namespace Users_Demo.Services.Implementation
{
    public class UserService : Repository<Users>, IUserService
    {
        public UserService(DbContext context) : base(context)
        {
        }

        public Task<List<Users>> GetByFirstName(string firstName) 
            => GetByFilter(i => i.FirstName == firstName).ToListAsync();

        public Task<List<Users>> GetByLastNameAsync(string lastName) 
            => GetByFilter(i => i.LastName == lastName).ToListAsync();
    }
}
