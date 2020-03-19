using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Users_Demo.DAL.Models;

namespace Users_Demo.Repository.Interface
{
    public interface IUserRepository
    {
        Task<bool> Create(Users data);
        Task<bool> Update(Users data);
        Task<bool> Delete(int id);
        IQueryable<Users> Get();
        Task<Users> GetByIdAsync(int id);
        IQueryable<Users> GetByFilter(Expression<Func<Users, bool>> filter = null);
    }
}
