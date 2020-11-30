using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.Models;

namespace Vehicles.ViewModels
{
    public class PostVehicleVM
    {
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Vin { get; set; }
        public int Type { get; set; }
        public int Color { get; set; }

        public Vehicle ToModel()
        {
            return new Vehicle
            {
                Make = this.Make,
                Model = this.Model,
                VIN = this.Vin,
                Type = (VehicleTypeEnum)this.Type,
                Color = (ColorEnum)this.Color
            };
        }
    }
}
