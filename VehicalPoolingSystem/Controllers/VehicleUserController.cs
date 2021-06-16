using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicalPoolingSystem.Models;
using VehicalPoolingSystem.Models.ViewModels;

namespace VehicalPoolingSystem.Controllers
{
    public class VehicleUserController : Controller
    {
        public readonly VehiclePoolingContext _context;

        public VehicleUserController(VehiclePoolingContext context)
        {
            _context = context;
        }
        public IActionResult Vehicles()
        {
            return View(_context.Vehicles.Where(v=>v.Available == true));
        }

        public IActionResult Bookings()
        {
            string userId = HttpContext.Session.GetString("UserId");
            return View(_context.Bookings.Include(b=>b.Vehicle).Where(u => u.UserId == userId));
        }
        public IActionResult BookingActivity(string bookingId)
        {
            Bookings b = _context.Bookings.FirstOrDefault(b => b.BookingId == bookingId);
            if(b.Status == "Booked")
            {
                b.Status = "PickedUp";
            }
            _context.Update(b);
            _context.SaveChanges();
            return RedirectToAction("Bookings");
        }

        [HttpPost]
        public IActionResult ReturnVhicle(string bookingId, string additionalDistance)
        {
            Bookings b = _context.Bookings.FirstOrDefault(b => b.BookingId == bookingId);
            if (b.Status == "PickedUp")
            {
                b.Status = "Returned";
            }
            b.AdditionalDistance = float.Parse(additionalDistance.ToString());

            double totalDays = (b.TripEnd - b.TripStart).TotalDays;

            b.TotalCharges = (totalDays * b.CostPerDay) + (b.AdditionalDistanceFee* b.AdditionalDistance);

            _context.Update(b);
            _context.SaveChanges();
            return RedirectToAction("Bookings");
        }

        public IActionResult BookingDetails(string bookingId)
        {
            return View(_context.Bookings.Include(b => b.Vehicle).FirstOrDefault(u => u.BookingId == bookingId));
        }

        public IActionResult VehicleDetails(string vehicleId)
        {
            Vehicles v = _context.Vehicles.FirstOrDefault(v => v.VehicleId == vehicleId);
            return View(new VehicleUserVehicleDetailsViewModel(v));
        }

        [HttpPost]
        public IActionResult BookVehicle(VehicleUserVehicleDetailsViewModel model)
        {
            model.Bookings.UserId = HttpContext.Session.GetString("UserId");
            model.Bookings.CreatedOn = DateTime.Now;
            model.Bookings.Status = "Booked";
            model.Bookings.BookingId = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            _context.Bookings.Add(model.Bookings);
            Vehicles v =_context.Vehicles.FirstOrDefault(v=>v.VehicleId == model.Bookings.VehicleId);
            v.Available = false;
            _context.Update(v);
            _context.SaveChanges();
            return RedirectToAction("Bookings");
        }

        public IActionResult AddReview(string bookingId, string vehicleId)
        {
            return View();
        }

    }
}