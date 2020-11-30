using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.Models;

namespace Vehicles.ViewModels
{
    public class VehicleUpdateViewModel
    {
        public string Vin { get; set; }
        public ColorEnum? Color { get; set; }
    }
}
