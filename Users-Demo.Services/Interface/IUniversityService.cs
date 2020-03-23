using System.Collections.Generic;
using System.Threading.Tasks;
using Users_Demo.DAL.Models;
using Users_Demo.Repository.Interface;

namespace Users_Demo.Services.Interface
{
    public interface IUniversityService : IRepository<University>
    {
        Task<List<University>> GetByName(string name);
    }
}
