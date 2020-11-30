using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.Models;

namespace Vehicles.Services
{
    public class AdoNetVehicleRepository : IVehicleRepository
    {
        private readonly IConfiguration _configuration;

        public AdoNetVehicleRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public void Add(Vehicle vehicle)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                conn.Open();

                
            }
        }

        public void Delete(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Vehicle Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> GetAll()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                conn.Open();

                var sql = "SELECT * FROM Vehicles;";

                using (var command = new SqlCommand(sql, conn))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var vehicle = new Vehicle
                        {
                            Id = (int)reader["Id"],
                            Make = (string)reader["Make"],
                            Model = (string)reader["Model"],
                            VIN = (string)reader["VIN"],
                            Type = (VehicleTypeEnum)reader["Type"],
                            Color = (ColorEnum)reader["Color"]
                        };

                        vehicles.Add(vehicle);
                    }
                }
            }

            return vehicles;
        }

        public void Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
