using JurneyTag.Core;
using JurneyTag.Model;
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
            throw new NotImplementedException();
        }

        public async Task<City> GetCity(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveCity(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCity(City city)
        {
            throw new NotImplementedException();
        }
    }
}
