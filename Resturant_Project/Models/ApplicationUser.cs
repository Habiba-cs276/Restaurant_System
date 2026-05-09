
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resturant_Project.Models
{
    public class ApplicationUser 
        //: IdentityUser
    {
        public int Id { get; set; } 
        public string UserName { get; set; }

        [DataType(DataType.Password)]   
        public string Password { get; set; } 
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }   

        [ValidateNever]
        public List<Order> Orders { get; set; } = new();
    }
}