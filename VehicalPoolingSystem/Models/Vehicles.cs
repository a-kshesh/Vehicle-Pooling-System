using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace VehicalPoolingSystem.Models
{
    public partial class Vehicles
    {
        public string VehicleId { get; set; }
        public string UserId { get; set; }
        
        [Required(ErrorMessage = "Vehicle's Type is required")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Vehicle's Owner Name is required")]
        public string OwnerName { get; set; }

        [Required(ErrorMessage = "Vehicle's License Number is required")]
        public string LicenseNumber { get; set; }

        [Required(ErrorMessage = "Vehicle's Company is required")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Vehicle's Model is required")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Vehicle's Manufacturing Year is required")]
        public string ManufacturingYear { get; set; }

        [Required(ErrorMessage = "Vehicle's Insurance Number is required")]
        public string InsuranceNumber { get; set; }

        [Required(ErrorMessage = "Vehicle's Transmission is required")]
        public string VehicleTransmission { get; set; }
        public string OwnershipDocFileName { get; set; }
        public string InsuranceDocFileName { get; set; }
        public string Image1Name { get; set; }
        public string Image2Name { get; set; }
        public string Image3Name { get; set; }

        [Required(ErrorMessage = "Vehicle's Pickup Address is required")]
        public string PickupAddress { get; set; }

        [Required(ErrorMessage = "Vehicle's Cost Per Day is required")]
        public double CostPerDay { get; set; }
        public bool? Available { get; set; }

        public virtual Users User { get; set; }

        public string PickupCity { get; set; }
        public string PickupState { get; set; }
        public string PickupZipCode { get; set; }
        public int VehicleDoors { get; set; }
        public int VehicleSeats { get; set; }
        public DateTime CreatedOn { get; set; }
        public string VehicleIgnition { get; set; }
        public int DistanceIncluded { get; set; }
        public double AdditionalDistanceFee { get; set; }



        public override string ToString()
        {
            return "VehicleId: "+ VehicleId+
                   "\nUserId: "+ UserId+
                   "\nType: "+ Type+
                   "\nOwnerName: "+ OwnerName+
                   "\nLicenseNumber: "+ LicenseNumber+
                   "\nCompany: "+ Company+
                   "\nModel: "+ Model+
                   "\nManufacturingYear: "+ ManufacturingYear+
                   "\nInsuranceNumber: "+ InsuranceNumber+
                   "\nVehicleTransmission: "+ VehicleTransmission+
                   "\nOwnershipDocFileName: "+ OwnershipDocFileName+
                   "\nInsuranceDocFileName: "+ InsuranceDocFileName+
                   "\nImage1Name: "+ Image1Name+
                   "\nImage2Name:"+ Image2Name+
                   "\nImage3Name:"+ Image3Name+
                   "\nPickupAddress"+ PickupAddress+
                   "\nCostPerDay"+ CostPerDay+
                   "\nAvailable"+ Available;
        }
    }
}
