using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehicalPoolingSystem.Models
{
    public partial class Users
    {
        public Users()
        {
            Vehicles = new HashSet<Vehicles>();
        }

        public string UserId { get; set; }
        
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Not a valid e-mail address.")]
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        
        [Required(ErrorMessage = "User Type is required")]
        public string Type { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public virtual ICollection<Vehicles> Vehicles { get; set; }

        public override string ToString()
        {
            return "UserId: " + UserId +
                    "\nFirstName: " + FirstName +
                    "\nLastName: " + LastName +
                    "\nType: " + Type +
                    "\nPassword: " + Password +
                    "\nPhone: " + Phone +
                    "\nAddress: " + Address +
                    "\nEmail: " + Email;
        }
    }
}
