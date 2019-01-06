using JurneyTag.Core;
using JurneyTag.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Peristence
{
    public class AccomodationRepository : IAccomodationRepository
    {
        public void AddAccomodation(Accomodation accomodation)
        {
            throw new NotImplementedException();
        }

        public Task<Accomodation> GetAccomodation(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Accomodation>> GetAccomodationByUser(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Accomodation>> GetAccomodations()
        {
            throw new NotImplementedException();
        }

        public void RemoveAccomodation(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccomodation(Accomodation accomodation)
        {
            throw new NotImplementedException();
        }
    }
}
