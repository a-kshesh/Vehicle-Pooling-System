using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicalPoolingSystem.Models.ViewModels
{
    public class NewVehicleViewModel
    {
        public Vehicles Vehicles { get; set; }
        public IFormFile Image1 { get; set; }
        public IFormFile Image2 { get; set; }
        public IFormFile Image3 { get; set; }
        public IFormFile InsuranceDoc { get; set; }
        public IFormFile OwnershipDoc { get; set; }

    }
}
