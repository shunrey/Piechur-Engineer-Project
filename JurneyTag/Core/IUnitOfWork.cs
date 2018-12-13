using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Core
{
    public interface IUnitOfWork
    {
        Task UpdateDatabase();
        Task RollbackTransaction();
        Task RefreshDatabase();
    }
}
