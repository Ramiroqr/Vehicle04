using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles04.API.Data.Entities;

namespace Vehicles04.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<DocumetType> DocumetTypes { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<VehiclePhoto> VehiclePhotos { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleTypes> VehicleTypes { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Procedure>()
                .HasIndex(x => x.Description).IsUnique();

            modelBuilder.Entity<VehicleTypes>()
                .HasIndex(x => x.Description).IsUnique();

            modelBuilder.Entity<Brand>()
                .HasIndex(x => x.Description).IsUnique();

            modelBuilder.Entity<DocumetType>()
                .HasIndex(x => x.Description).IsUnique();

            modelBuilder.Entity<Vehicle>()
                .HasIndex(x => x.Plaque).IsUnique();
        }
    }
}
