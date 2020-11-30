using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.Models;

namespace Vehicles.Entities
{
    public class VehicleDbContext : DbContext
    {
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=MSI\SQLEXPRESS;Database=Vehicle;Integrated Security=True");
        }
    }
}
