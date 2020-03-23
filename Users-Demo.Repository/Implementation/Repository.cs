using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Users_Demo.DAL;
using Users_Demo.Repository.Interface;

namespace Users_Demo.Repository.Implementation
{
    public class Repository<TContext> : IRepository
    where TContext : UsersDemoContext
    {
        private readonly UsersDemoContext _context;

        public Repository(TContext context)
        {
            _context = context;
        }
        public async Task<bool> Create<TModel>(TModel data) where TModel : class
        {
            _context.Set<TModel>().Add(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update<TModel>(TModel data) where TModel : class
        {
            _context.Set<TModel>().Attach(data);
            _context.Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete<TModel>(TModel data) where TModel : class
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

        public IQueryable<TModel> Get<TModel>() where TModel : class => _context.Set<TModel>();

        public async Task<TModel> GetByIdAsync<TModel>(int id) where TModel : class => await _context.Set<TModel>().FindAsync(id);

        public IQueryable<TModel> GetByFilter<TModel>(Expression<Func<TModel, bool>> filter = null) where TModel : class => _context.Set<TModel>().Where(filter);
    }
}
