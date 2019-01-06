using JurneyTag.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Core
{
    public interface IAttractionRepository
    {
        Task<Attraction> GetAttraction(int id);
        Task<IEnumerable<Attraction>> GetAttractions();
        Task<IEnumerable<Attraction>> GetAttractionsByUser(string userId);
        void AddAttraction(Attraction attraction);
        void RemoveAttraction(int id);
        void UpdateAttraction(Attraction attraction);
    }
}
