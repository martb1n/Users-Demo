using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Users_Demo.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<bool> CreateAsync(TEntity data);

        Task<bool> UpdateAsync(TEntity data);

        Task<bool> DeleteAsync(TEntity data);

        Task<bool> DeleteAsync(int id);

        IQueryable<TEntity> Get();

        Task<TEntity> GetByIdAsync(int id);

        IQueryable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter = null);
    }
}