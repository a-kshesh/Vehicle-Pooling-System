using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehicalPoolingSystem.Models;

namespace VehicalPoolingSystem.Controllers
{
    public class UsersController : Controller
    {
        private readonly VehiclePoolingContext _context;

        public UsersController(VehiclePoolingContext context)
        {
            _context = context;
        }

        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser(Users u)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            u.UserId = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            _context.Users.Add(u);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UserProfile()
        {
            var user = _context.Users.Find(HttpContext.Session.GetString("UserId"));
            return View(user);
        }

        public IActionResult UserEdit()
        {
            var user = _context.Users.Find(HttpContext.Session.GetString("UserId"));
            return View(user);
        }

        [HttpPost]
        public IActionResult UserEdit(Users u)
        {           
            _context.Update(u);
            _context.SaveChanges();
            HttpContext.Session.Clear();
            SetSession(u);
            return RedirectToAction("UserProfile");
          
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
    }
}