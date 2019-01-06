using JurneyTag.Core.Models;
using JurneyTag.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurneyTag.Peristence
{
    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options)
            : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Accomodation> Accomodations { get; set; }
    }
}
