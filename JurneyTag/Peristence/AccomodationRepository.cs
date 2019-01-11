using JurneyTag.Core;
using JurneyTag.Core.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Peristence
{
    public class AccomodationRepository : IAccomodationRepository
    {
        private readonly ServiceDbContext _serviceDbContext;

        public AccomodationRepository(ServiceDbContext serviceDbContext )
        {
            _serviceDbContext = serviceDbContext;
        }

        public void AddAccomodation(Accomodation accomodation)
        {
            if (accomodation == null)
                throw new ArgumentNullException();

            _serviceDbContext.Accomodations.Add(accomodation);
        }

        public async Task<Accomodation> GetAccomodation(int id)
        {
            return await _serviceDbContext.Accomodations.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Accomodation>> GetAccomodationsByUser(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Accomodation>> GetAccomodations()
        {
            return await _serviceDbContext.Accomodations.Include(a => a.Alimentations)
                                                        .Include(r => r.Rooms)
                                                        .ToListAsync();
        }

        public void RemoveAccomodation(int id)
        {
           var accomodationToRemove = _serviceDbContext.Accomodations.SingleOrDefault(a => a.Id == id);
            _serviceDbContext.Accomodations.Remove(accomodationToRemove);
        }

        public void UpdateAccomodation(Accomodation accomodation)
        {
            throw new NotImplementedException();
        }
    }
}
