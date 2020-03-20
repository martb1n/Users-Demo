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
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(Users data)
        {
            try
            {
                await _repository.Create(data);
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
                await _repository.Delete(id);
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
                var user = await Task.Run(() => _repository.Get());
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
                var user = await Task.Run(() => _repository.GetByFilter(filter: i => i.FirstName == firstName));
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
                var user = await _repository.GetByIdAsync(id);
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
                var user = await Task.Run(() => _repository.GetByFilter(filter: i => i.LastName == lastName));
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
                await _repository.Update(data);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
