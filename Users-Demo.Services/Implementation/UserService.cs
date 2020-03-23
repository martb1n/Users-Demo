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
        private readonly BaseRepository<Users> _baseRepository;
        public UserService(UsersDemoContext context)
        {
            _baseRepository = new UsersRepository(context);
        }

        public async Task<bool> Create(Users data)
        {
            try
            {
                await _baseRepository.Create(data);
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
                await _baseRepository.Delete(id);
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
                var user = await Task.Run(() => _baseRepository.Get());
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
                var user = await Task.Run(() => _baseRepository.GetByFilter(filter: i => i.FirstName == firstName));
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
                var user = await _baseRepository.GetByIdAsync(id);
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
                var user = await Task.Run(() => _baseRepository.GetByFilter(filter: i => i.LastName == lastName));
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
                await _baseRepository.Update(data);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
