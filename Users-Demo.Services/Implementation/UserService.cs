using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Users_Demo.DAL;
using Users_Demo.DAL.Models;
using Users_Demo.Repository.Base;
using Users_Demo.Repository.Implementation;
using Users_Demo.Services.Interface;

namespace Users_Demo.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UsersDemoContext _context;

        public UserService(UsersDemoContext context)
        {
            _context = context;
        }

        public BaseRepository<Users> GetBaseRepository()
        {
            return new UsersRepository(_context);
        }

        public async Task<bool> Create(Users data)
        {
            try
            {
                await GetBaseRepository().Create(data);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await GetBaseRepository().Delete(id);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<Users>> Get()
        {
            try
            {
                var user = await Task.Run(() => GetBaseRepository().Get());
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Users>> GetByFirstName(string firstName)
        {
            try
            {
                var user = await Task.Run(() => GetBaseRepository().GetByFilter(filter: i => i.FirstName == firstName));
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Users> GetById(int id)
        {
            try
            {
                var user = await GetBaseRepository().GetByIdAsync(id);
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Users>> GetByLastname(string lastName)
        {
            try
            {
                var user = await Task.Run(() => GetBaseRepository().GetByFilter(filter: i => i.LastName == lastName));
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Update(Users data)
        {
            try
            {
                await GetBaseRepository().Update(data);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
