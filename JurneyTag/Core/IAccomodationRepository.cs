using JurneyTag.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Core
{
    public interface IAccomodationRepository
    {
        Task<Accomodation> GetAccomodation(int id);
        Task<IEnumerable<Accomodation>> GetAccomodations();
        Task<IEnumerable<Accomodation>> GetAccomodationByUser(string userId);
        void AddAccomodation(Accomodation accomodation);
        void RemoveAccomodation(int id);
        void UpdateAccomodation(Accomodation accomodation);
    }
}
