using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Users_Demo.Repository.Interface;

namespace Users_Demo.Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
            Set = _context.Set<TEntity>();
        }

        protected DbSet<TEntity> Set { get; }

        public async Task<bool> CreateAsync(TEntity data)
        {
            Set.Add(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(TEntity data)
        {
            Set.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(TEntity data)
        {
            if (_context.Entry(data).State == EntityState.Detached)
            {
                Set.Attach(data);
            }

            Set.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            return await DeleteAsync(entity);
        }

        public IQueryable<TEntity> Get() => Set;

        public async Task<TEntity> GetByIdAsync(int id) => await Set.FindAsync(id);

        public IQueryable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter = null) => _context.Set<TEntity>().Where(filter);
    }
}
