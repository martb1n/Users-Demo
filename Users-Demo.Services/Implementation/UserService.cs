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
        private readonly IRepository _repository;
        public UserService(IRepository repository)
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
                var user = await _repository.GetByIdAsync<Users>(id);
                if (user == null)
                    return false;
                await _repository.Delete(user);
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
                var user = await Task.Run(() => _repository.Get<Users>());
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
                var user = await Task.Run(() => _repository.GetByFilter<Users>(i => i.FirstName == firstName));
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
                var user = await _repository.GetByIdAsync<Users>(id);
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
                var user = await Task.Run(() => _repository.GetByFilter<Users>(filter: i => i.LastName == lastName));
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
