using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Users_Demo.DAL;
using Users_Demo.Repository.Interface;

namespace Users_Demo.Repository.Implementation
{
    public class Repository<TModel> : IRepository<TModel>
    where TModel : UsersDemoContext
    {
        private readonly UsersDemoContext _context;

        public Repository(UsersDemoContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(TModel data)
        {
            _context.Set<TModel>().Add(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(TModel data)
        {
            _context.Set<TModel>().Attach(data);
            _context.Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(TModel data)
        {
            var dbSet = _context.Set<TModel>();
            if (_context.Entry(data).State == EntityState.Detached)
            {
                dbSet.Attach(data);
            }
            dbSet.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<TModel> Get() => _context.Set<TModel>();

        public async Task<TModel> GetByIdAsync(int id) => await _context.Set<TModel>().FindAsync(id);

        public IQueryable<TModel> GetByFilter(Expression<Func<TModel, bool>> filter = null) => _context.Set<TModel>().Where(filter);
    }
}
