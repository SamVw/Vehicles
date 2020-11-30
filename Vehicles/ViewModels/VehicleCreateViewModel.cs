using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.Models;

namespace Vehicles.ViewModels
{
    public class VehicleCreateViewModel
    {
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Vin { get; set; }
        public VehicleTypeEnum Type { get; set; }
        public ColorEnum Color { get; set; }

        public Vehicle ToModel()
        {
            return new Vehicle
            {
                Make = this.Make,
                Model = this.Model,
                VIN = this.Vin,
                Type = this.Type,
                Color = this.Color
            };
        }
    }
}
