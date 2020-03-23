using System.Collections.Generic;
using System.Threading.Tasks;
using Users_Demo.DAL.Models;
using Users_Demo.Repository.Interface;

namespace Users_Demo.Services.Interface
{
    public interface IUserService : IRepository<Users>
    {
        Task<List<Users>> GetByFirstName(string firstName);
        Task<List<Users>> GetByLastNameAsync(string lastName);
    }
}
