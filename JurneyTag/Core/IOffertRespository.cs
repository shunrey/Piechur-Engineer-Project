using JurneyTag.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Core
{
    public interface IOffertRespository
    {
        Task<Offert> GetOffert(int id);
        Task<IEnumerable<Offert>> GetOfferts();
        Task<IEnumerable<Offert>> GetOffertsByUser(string userId);
        void AddOffert(Offert offert);
        void RemoveOffert(int id);
        void UpdateOffert(Offert offert);
        void AddClient(ClientInfo client);
        Task<IEnumerable<ClientInfo>> GetClientsInfo(int offertId);
    }
}
