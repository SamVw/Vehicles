using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.Models;
using Vehicles.Services;
using Vehicles.ViewModels;

namespace Vehicles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public HomeController(IVehicleRepository vehicleRepository)
        {
            this._vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public IEnumerable<Vehicle> GetAll() => _vehicleRepository.GetAll();

        [HttpGet]
        [Route("{id:int}")]
        public Vehicle GetById(int id) => _vehicleRepository.Get(id);

        [HttpPost]
        public void Add(VehicleCreateViewModel vehicle)
        {
            _vehicleRepository.Add(vehicle.ToModel());
        }

        [HttpPut]
        [Route("{id:int}")]
        public void Update(int id, [FromBody] VehicleUpdateViewModel updates)
        {
            var vehicle =_vehicleRepository.Get(id);

            if (updates.Vin != null)
            {
                vehicle.VIN = updates.Vin;
            }

            if (updates.Color != null)
            {
                vehicle.Color = (ColorEnum)updates.Color;
            }

            _vehicleRepository.Update(vehicle);
        }
    }
}
