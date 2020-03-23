using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Users_Demo.DAL;

namespace Users_Demo.Repository.Interface
{
    public interface IRepository
    {
        Task<bool> Create<TModel>(TModel data)
            where TModel : class;

        Task<bool> Update<TModel>(TModel data)
            where TModel : class;

        Task<bool> Delete<TModel>(TModel data)
            where TModel : class;

        IQueryable<TModel> Get<TModel>()
            where TModel : class;

        Task<TModel> GetByIdAsync<TModel>(int id)
            where TModel : class;

        IQueryable<TModel> GetByFilter<TModel>(Expression<Func<TModel, bool>> filter = null)
            where TModel : class;
    }
}
