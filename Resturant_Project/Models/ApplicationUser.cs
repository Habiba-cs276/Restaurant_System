
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resturant_Project.Models
{
    public class ApplicationUser
        : IdentityUser
    {
        [ValidateNever]
        public List<Order> Orders { get; set; } = new();
    }
}