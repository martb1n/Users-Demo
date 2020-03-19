using System.Collections.Generic;
using System.Threading.Tasks;
using Users_Demo.DAL.Models;

namespace Users_Demo.Services.Interface
{
    public interface IUserService
    {
        Task<bool> Create(Users data);
        Task<bool> Update(Users data);
        Task<bool> Delete(int id);
        Task<Users> GetById(int id);
        Task<IEnumerable<Users>> Get();
        Task<IEnumerable<Users>> GetByFirstName(string firstName);
        Task<IEnumerable<Users>> GetByLastname(string lastName);
    }
}
