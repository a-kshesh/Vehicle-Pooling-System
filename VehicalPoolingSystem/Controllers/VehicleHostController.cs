using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using SQLitePCL;
using VehicalPoolingSystem.Models;
using VehicalPoolingSystem.Models.ViewModels;

namespace VehicalPoolingSystem.Controllers
{
    public class VehicleHostController : Controller
    {
        private readonly VehiclePoolingContext _context;
        private readonly IWebHostEnvironment _iwebhost;
        public VehicleHostController(VehiclePoolingContext context, IWebHostEnvironment iwebhost)
        {
            _context = context;
            _iwebhost = iwebhost;
        }

        public IActionResult Bookings()
        {
            string userId = HttpContext.Session.GetString("UserId");
            return View(_context.Bookings.Include(b => b.Vehicle)
                                         .Include(b => b.User)
                                         .Where(u => u.Vehicle.UserId== userId));
        }
        public IActionResult Acknowledge(string bookingId)
        {
            Bookings b = _context.Bookings.Include(b => b.Vehicle).FirstOrDefault(b=>b.BookingId == bookingId);
            if(b.Status == "Returned")
            {
                b.Status = "Completed";
                b.Vehicle.Available = true;
            }
            _context.Update(b);
            _context.SaveChanges();
            return RedirectToAction("Bookings");
        }

        public IActionResult Vehicles()
        {
            string userId = HttpContext.Session.GetString("UserId");
            return View(new VehiclesViewModel(_context.Vehicles.Where(u => u.UserId == userId)));
        }

        public IActionResult NewVehicle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewVehicle(NewVehicleViewModel v)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            v.Vehicles.CreatedOn = DateTime.Now;
            v.Vehicles.VehicleDoors = Int32.Parse(v.Vehicles.VehicleDoors.ToString());
            v.Vehicles.VehicleSeats = Int32.Parse(v.Vehicles.VehicleSeats.ToString());
            v.Vehicles.CostPerDay = float.Parse(v.Vehicles.CostPerDay.ToString());
            v.Vehicles.AdditionalDistanceFee = float.Parse(v.Vehicles.AdditionalDistanceFee.ToString());
            v.Vehicles.DistanceIncluded = Int32.Parse(v.Vehicles.DistanceIncluded.ToString());

            v.Vehicles.UserId = HttpContext.Session.GetString("UserId");
            v.Vehicles.VehicleId = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            v.Vehicles.Available = true;
            if (v.InsuranceDoc != null)
            {
                v.Vehicles.InsuranceDocFileName = saveFiles(v.InsuranceDoc);
            }
            if (v.OwnershipDoc != null)
            {
                v.Vehicles.OwnershipDocFileName = saveFiles(v.OwnershipDoc);
            }
            if(v.Image1 != null)
            {
                v.Vehicles.Image1Name = saveFiles(v.Image1);
            }
            if(v.Image2 != null)
            {
                v.Vehicles.Image2Name = saveFiles(v.Image2);
            }
            if(v.Image3 != null)
            {
                v.Vehicles.Image3Name = saveFiles(v.Image3);
            }
            
            _context.Vehicles.Add(v.Vehicles);
            _context.SaveChanges();

            string userId = HttpContext.Session.GetString("UserId");
            return View("Vehicles",new VehiclesViewModel(_context.Vehicles.Where(u => u.UserId == userId)));
        }

        public IActionResult VehicleDetails(string vehicleId)
        {
            return View(_context.Vehicles.FirstOrDefault(v=>v.VehicleId == vehicleId));
        }

        public IActionResult VehicleEdit(string vehicleId)
        {
            return View(_context.Vehicles.FirstOrDefault(v => v.VehicleId == vehicleId));
        }

        [HttpPost]
        public IActionResult VehicleEdit(Vehicles v)
        {
            v.VehicleDoors = Int32.Parse(v.VehicleDoors.ToString());
            v.VehicleSeats = Int32.Parse(v.VehicleSeats.ToString());
            v.CostPerDay = float.Parse(v.CostPerDay.ToString());
            v.AdditionalDistanceFee = float.Parse(v.AdditionalDistanceFee.ToString());
            v.DistanceIncluded = Int32.Parse(v.DistanceIncluded.ToString());

            _context.Update(v);
            _context.SaveChanges();
            return RedirectToAction("VehicleDetails",new { vehicleId = v.VehicleId } );
        }

        public string saveFiles(IFormFile f)
        {
            string uploadsFolder = Path.Combine(_iwebhost.WebRootPath, "uploads");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + f.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            f.CopyTo(new FileStream(filePath, FileMode.Create));
            return uniqueFileName;
        }
    }
}