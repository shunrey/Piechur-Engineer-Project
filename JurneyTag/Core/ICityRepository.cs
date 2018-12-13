using JurneyTag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Core
{
    public interface ICityRepository
    {
        Task<City> GetCity(int id);
        Task<IEnumerable<City>> GetCities();
        Task<IEnumerable<City>> GetCitiesByUser(string userId);
        void AddCity(City city);
        void RemoveCity(int id);
        void UpdateCity(City city);
    }
}
