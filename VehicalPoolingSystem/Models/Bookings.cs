using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicalPoolingSystem.Models
{
    public partial class Bookings
    {
        public string BookingId { get; set; }
        public string VehicleId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime TripStart { get; set; }
        public DateTime TripEnd { get; set; }
        public string PickupAddress { get; set; }
        public string Status { get; set; }
        public double CostPerDay { get; set; }
        public double AdditionalDistanceFee { get; set; }
        public int DistanceIncluded { get; set; }
        public double AdditionalDistance { get; set; }
        public double TotalCharges { get; set; }
        public virtual Users User { get; set; }
        public virtual Vehicles Vehicle { get; set; }


        public override string ToString()
        {
            return "BookingID: "+BookingId+"\n"+
                   "UserId: "+UserId+"\n"+
                   "VehicleId: "+VehicleId+"\n"+
                   "Status: "+Status+"\n"+
                   "CostPerDay: "+CostPerDay+"\n"+
                   "CreatedOn: "+CreatedOn+"\n"+
                   "TripStart: "+TripStart+"\n"+
                   "TripEnd: "+TripEnd+"\n"+
                   "AdditionalDistanceFee:"+ AdditionalDistanceFee+"\n"+
                   "DistanceIncluded: "+ DistanceIncluded + "\n"+
                   "AdditionalDistance:"+ AdditionalDistance+"\n"+
                   "TotalCharges: "+ TotalCharges+"\n"+
                   "PickupAddress: "+PickupAddress;
        }

    }
}
