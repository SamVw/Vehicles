using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.Entities;
using Vehicles.Models;

namespace Vehicles.Services
{
    public class EfVehicleRepository : IVehicleRepository
    {
        private readonly VehicleDbContext _dbContext;

        public EfVehicleRepository(VehicleDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(Vehicle vehicle)
        {
            _dbContext.Vehicles.Add(vehicle);
            _dbContext.SaveChanges();
        }

        public void Delete(Vehicle vehicle)
        {
            _dbContext.Vehicles.Remove(vehicle);
            _dbContext.SaveChanges();
        }

        public Vehicle Get(int id)
        {
            return _dbContext.Vehicles.FirstOrDefault(v => v.Id == id);
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return _dbContext.Vehicles;
        }

        public void Update(Vehicle vehicle)
        {
            _dbContext.Vehicles.Update(vehicle);
            _dbContext.SaveChanges();
        }
    }
}
