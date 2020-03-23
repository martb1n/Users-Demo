using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Users_Demo.DAL.Models;
using Users_Demo.Repository.Implementation;
using Users_Demo.Services.Interface;

namespace Users_Demo.Services.Implementation
{
    public class UniversityService : Repository<University>, IUniversityService
    {
        public UniversityService(DbContext context) : base(context)
        {
        }

        public Task<List<University>> GetByName(string name) => GetByFilter(filter: i => i.Name == name).ToListAsync();
    }
}
