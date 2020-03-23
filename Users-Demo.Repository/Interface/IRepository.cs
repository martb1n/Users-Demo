using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Users_Demo.Repository.Interface
{
    public interface IRepository<TModel>
    {
        Task<bool> Create(TModel data);
        Task<bool> Update(TModel data);
        Task<bool> Delete(TModel data);
        IQueryable<TModel> Get();
        Task<TModel> GetByIdAsync(int id);
        IQueryable<TModel> GetByFilter(Expression<Func<TModel, bool>> filter = null);
    }
}
