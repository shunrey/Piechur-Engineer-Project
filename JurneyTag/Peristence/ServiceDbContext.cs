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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OffertAttraction>()
                .HasKey(bc => new { bc.AttractionId, bc.OffertId });
            modelBuilder.Entity<OffertAttraction>()
                .HasOne(bc => bc.Attraction)
                .WithMany(b => b.OffertAttractions)
                .HasForeignKey(bc => bc.AttractionId);
            modelBuilder.Entity<OffertAttraction>()
                .HasOne(bc => bc.Offert)
                .WithMany(c => c.OffertAttractions)
                .HasForeignKey(bc => bc.OffertId);
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Accomodation> Accomodations { get; set; }
        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<Alimentation> Alimentations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Offert> Offerts { get; set; }
        public DbSet<OffertAttraction> OffertAttractions { get; set; }
        public DbSet<ClientInfo> ClientsInfo { get; set; }
    }
}
