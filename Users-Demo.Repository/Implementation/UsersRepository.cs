using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Users_Demo.DAL;
using Users_Demo.DAL.Models;
using Users_Demo.Repository.Base;

namespace Users_Demo.Repository.Implementation
{
    public class UsersRepository : BaseRepository<Users>
    {
        private readonly UsersDemoContext _context;
        public UsersRepository(UsersDemoContext context)
        {
            _context = context;
        }
        public override async Task<bool> Create(Users data)
        {
            _context.Set<Users>().Add(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(Users data)
        {
            _context.Set<Users>().Attach(data);
            _context.Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(int id)
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

        public override IQueryable<Users> Get() => _context.Users;

        public override async Task<Users> GetByIdAsync(int id) => await _context.Set<Users>().FindAsync(id);

        public override IQueryable<Users> GetByFilter(Expression<Func<Users, bool>> filter = null) => _context.Set<Users>().Where(filter);
    }
}
