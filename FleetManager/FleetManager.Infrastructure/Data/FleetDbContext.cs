using FleetManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Infrastructure.Data
{

    public class FleetDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().OwnsOne(v => v.ChassisId);
        }


        public FleetDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Vehicle> Vehicles { get; set; }

    }
}
