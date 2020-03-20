using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Users_Demo.DAL;
using Users_Demo.DAL.Models;
using Users_Demo.Repository.Interface;

namespace Users_Demo.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersDemoContext _context;
        public UserRepository(UsersDemoContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Users data)
        {
            _context.Set<Users>().Add(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return false;
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return true;
        }

        public IQueryable<Users> Get() => _context.Users;

        public IQueryable<Users> GetByFilter(Expression<Func<Users, bool>> filter = null) => _context.Set<Users>().Where(filter);

        public async Task<Users> GetByIdAsync(int id) => await _context.Set<Users>().FindAsync(id);

        public async Task<bool> Update(Users data)
        {
            _context.Set<Users>().Attach(data);
            _context.Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
