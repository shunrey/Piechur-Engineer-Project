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
        public void AddAttraction(Attraction attraction)
        {
            throw new NotImplementedException();
        }

        public Task<Attraction> GetAttraction(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Attraction>> GetAttractions()
        {
            throw new NotImplementedException();
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
