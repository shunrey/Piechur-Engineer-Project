using JurneyTag.Core;
using JurneyTag.Models;
using JurneyTag.Utilities.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Peristence
{
    public class CityRepository : ICityRepository
    {
        private readonly ServiceDbContext _serviceDbContext;

        public CityRepository(ServiceDbContext serviceDbContext)
        {
            _serviceDbContext = serviceDbContext;
        }

        public void AddCity(City city)
        {
            if (city == null)
                throw new ArgumentNullException();

           _serviceDbContext.Cities.Add(city);
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            return await _serviceDbContext.Cities.ToListAsync();
        }


        public async Task<IEnumerable<City>> GetCitiesByUser(string userId)
        {
            return await _serviceDbContext.Cities.Where(c => c.Name == userId).ToListAsync();
        }

       
        public async Task<City> GetCity(int id)
        {
            return await _serviceDbContext.Cities.SingleOrDefaultAsync(c => c.Id == id);
        }

        public void RemoveCity(int id)
        {
            var cityToRemove = _serviceDbContext.Cities.SingleOrDefault(c => c.Id == id);
            _serviceDbContext.Cities.Remove(cityToRemove);
        }

        public void UpdateCity(City city)
        {
            var cityFromDb = _serviceDbContext.Cities.SingleOrDefault(c => c.Id == city.Id);
            CityMapper.SetCityToUpdate(cityFromDb, city);
        }
    }
}
