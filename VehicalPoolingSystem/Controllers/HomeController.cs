using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VehicalPoolingSystem.Models;
using VehicalPoolingSystem.Models.ViewModels;

namespace VehicalPoolingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VehiclePoolingContext _context;

        public HomeController(ILogger<HomeController> logger, VehiclePoolingContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInViewModel s)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            var newUser = _context.Users.FirstOrDefault(m => m.Email == s.Email);
            if (newUser != null)
            {
                if (newUser.Password == s.Password)
                {
                    SetSession(newUser);
                    if (newUser.Type == "VehicleHost")
                    {
                        return RedirectToAction("Vehicles", "VehicleHost");
                    }
                    else
                    {
                        return RedirectToAction("Vehicles", "VehicleUser");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Incorrect Passowrd";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Incorrect Username";
                return View("Index");
            }
        }     

        public IActionResult SignOut()
        {

            HttpContext.Session.Clear();
            //Session.Abandon();
            return RedirectToAction("index", "home");
        }
        public void SetSession(Users u)
        {
            HttpContext.Session.SetString("UserId", u.UserId);
            HttpContext.Session.SetString("FirstName", u.FirstName);
            HttpContext.Session.SetString("LastName", u.LastName);
            HttpContext.Session.SetString("Email", u.Email);
            HttpContext.Session.SetString("Phone", u.Phone);
            HttpContext.Session.SetString("Address", u.Address);
            HttpContext.Session.SetString("type", u.Type);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
