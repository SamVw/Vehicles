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
        public IEnumerable<Vehicle> GetAll() 
        {
            return _vehicleRepository.GetAll();
        }

        [HttpPost]
        public void Post(VehicleCreateViewModel vehicle)
        {
            _vehicleRepository.Add(vehicle.ToModel());
        }
    }
}
