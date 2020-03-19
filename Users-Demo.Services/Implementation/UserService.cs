using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Users_Demo.DAL.Models;
using Users_Demo.Repository.Interface;
using Users_Demo.Services.Interface;

namespace Users_Demo.Services.Implementation
{
    public class UserService : IUserService
    {
        public readonly IUserRepository repository;
        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }
        public async Task<bool> Create(Users data)
        {
            try
            {
                await repository.Create(data);
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
                await repository.Delete(id);
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
                var user = await Task.Run(() => repository.Get());
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
                var user = await Task.Run(() => repository.GetByFilter(filter: i => i.FirstName == firstName));
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
                var user = await repository.GetByIdAsync(id);
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
                var user = await Task.Run(() => repository.GetByFilter(filter: i => i.LastName == lastName));
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
                await repository.Update(data);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
