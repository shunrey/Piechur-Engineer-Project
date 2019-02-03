using JurneyTag.Core;
using JurneyTag.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JurneyTag.Peristence
{
    public class OffertRepository : IOffertRespository
    {
        private readonly ServiceDbContext _serviceDbContext;

        public OffertRepository(ServiceDbContext serviceDbContext)
        {
            _serviceDbContext = serviceDbContext;
        }

        public void AddClient(ClientInfo client)
        {
            _serviceDbContext.ClientsInfo.Add(client);
        }

        public void AddOffert(Offert offert)
        {
            _serviceDbContext.Offerts.Add(offert);
        }

        public async Task<IEnumerable<ClientInfo>> GetClientsInfo(int offertId)
        {
            return await _serviceDbContext.ClientsInfo.Where(c => c.OffertId == offertId).ToListAsync();
        }

        public async Task<Offert> GetOffert(int id)
        {
            return await _serviceDbContext.Offerts.Include(oa => oa.OffertAttractions)
                                                   .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Offert>> GetOfferts()
        {
            return await _serviceDbContext.Offerts.Include(oa => oa.OffertAttractions)
                                                   .ToListAsync();
        }

        public Task<IEnumerable<Offert>> GetOffertsByUser(string userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveOffert(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOffert(Offert offert)
        {
            throw new NotImplementedException();
        }
    }
}
