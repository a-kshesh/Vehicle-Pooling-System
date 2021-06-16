using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicalPoolingSystem.Models.ViewModels
{
    public class VehiclesViewModel
    {
        public IEnumerable<Vehicles> Vehicles { get; set; }
        public VehiclesViewModel() { }
        public VehiclesViewModel(IEnumerable<Vehicles> vehicles)
        {
            Vehicles = vehicles;

        }
    }
}
