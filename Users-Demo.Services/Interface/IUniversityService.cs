using System.Collections.Generic;
using System.Threading.Tasks;
using Users_Demo.DAL.Models;

namespace Users_Demo.Services.Interface
{
    public interface IUniversityService
    {
        Task<bool> Create(University data);
        Task<bool> Update(University data);
        Task<bool> Delete(int id);
        Task<University> GetById(int id);
        Task<IEnumerable<University>> Get();
        Task<IEnumerable<University>> GetByName(string name);
    }
}
