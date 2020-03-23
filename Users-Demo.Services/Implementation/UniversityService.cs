using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Users_Demo.DAL.Models;
using Users_Demo.Repository.Interface;
using Users_Demo.Services.Interface;

namespace Users_Demo.Services.Implementation
{
    public class UniversityService : IUniversityService
    {
        private readonly IRepository _repository; 
        public UniversityService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(University data)
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

        public async Task<bool> Update(University data)
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

        public async Task<bool> Delete(int id)
        {
            
            try
            {
                var university = await _repository.GetByIdAsync<University>(id);
                if (university == null)
                    return false;
                await _repository.Delete(university);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<University> GetById(int id)
        {
            try
            {
                var university = await _repository.GetByIdAsync<University>(id);
                return university;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<University>> Get()
        {
            try
            {
                var university = await Task.Run(() => _repository.Get<University>());
                return university;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<University>> GetByName(string name)
        {
            try
            {
                var university = await Task.Run(() => _repository.GetByFilter<University>(filter: i => i.Name == name));
                return university;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
