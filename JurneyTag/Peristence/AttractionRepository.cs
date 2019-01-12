using JurneyTag.Core;
using JurneyTag.Core.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Peristence
{
    public class AttractionRepository : IAttractionRepository
    {

        private readonly ServiceDbContext _serviceDbContext;

        public AttractionRepository(ServiceDbContext serviceDbContext)
        {
            _serviceDbContext = serviceDbContext;
        }

        public void AddAttraction(Attraction attraction)
        {
            _serviceDbContext.Attractions.Add(attraction);
        }

        public async Task<Attraction> GetAttraction(int id)
        {
           return await _serviceDbContext.Attractions.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Attraction>> GetAttractions()
        {
            return await _serviceDbContext.Attractions.ToListAsync();
        }

        public Task<IEnumerable<Attraction>> GetAttractionsByUser(string userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveAttraction(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAttraction(Attraction attraction)
        {
            throw new NotImplementedException();
        }
    }
}
