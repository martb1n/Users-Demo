using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Users_Demo.Repository.Base
{
    public abstract class BaseRepository<T>
    {
        public abstract Task<bool> Create(T data);
        public abstract Task<bool> Update(T data);
        public abstract Task<bool> Delete(int id);
        public abstract IQueryable<T> Get();
        public abstract Task<T> GetByIdAsync(int id);
        public abstract IQueryable<T> GetByFilter(Expression<Func<T, bool>> filter = null);
    }
}
