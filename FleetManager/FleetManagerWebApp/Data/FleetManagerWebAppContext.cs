using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FleetManager.Domain.Entities;

namespace FleetManagerWebApp.Data
{
    public class FleetManagerWebAppContext : DbContext
    {
        public FleetManagerWebAppContext (DbContextOptions<FleetManagerWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<FleetManager.Domain.Entities.Vehicle> Vehicle { get; set; } = default!;
    }
}
