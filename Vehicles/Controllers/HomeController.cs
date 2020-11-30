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
        public ActionResult<Vehicle> GetById(int id) 
        {
            var vehicle = _vehicleRepository.Get(id);
            if (vehicle == null) return new NotFoundResult();

            return new OkObjectResult(vehicle);
        }

        [HttpPost]
        public ActionResult Add(VehicleCreateViewModel vehicle)
        {
            _vehicleRepository.Add(vehicle.ToModel());

            return Ok();
        }

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult Update(int id, [FromBody] VehicleUpdateViewModel updates)
        {
            var vehicle =_vehicleRepository.Get(id);
            if (vehicle == null) return new NotFoundResult();

            if (updates.Vin != null)
            {
                vehicle.VIN = updates.Vin;
            }

            if (updates.Color != null)
            {
                vehicle.Color = (ColorEnum)updates.Color;
            }

            _vehicleRepository.Update(vehicle);

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            var vehicle = _vehicleRepository.Get(id);
            if (vehicle == null) return new NotFoundResult();

            _vehicleRepository.Delete(vehicle);
            return Ok();
        }
    }
}
