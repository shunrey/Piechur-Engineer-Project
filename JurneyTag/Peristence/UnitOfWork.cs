using JurneyTag.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Peristence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ServiceDbContext _serviceDbContext;

        public UnitOfWork(ServiceDbContext serviceDbContext)
        {
            _serviceDbContext = serviceDbContext;
        } 

        public async Task UpdateDatabase()
        {
           await _serviceDbContext.SaveChangesAsync();
        }
        
        public async Task RefreshDatabase()
        {
           throw new NotImplementedException();
        }

        public async Task RollbackTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
