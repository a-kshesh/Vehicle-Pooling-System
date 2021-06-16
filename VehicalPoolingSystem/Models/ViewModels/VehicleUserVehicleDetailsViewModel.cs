using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicalPoolingSystem.Models.ViewModels
{
    public class VehicleUserVehicleDetailsViewModel
    {
        public Vehicles Vehicles { get; set; }
        public Bookings Bookings { get; set; }
        public VehicleUserVehicleDetailsViewModel(Vehicles vehicles)
        {
            Vehicles = vehicles;
            //Bookings = new Bookings();
        }
        public VehicleUserVehicleDetailsViewModel() { }

    }
}
