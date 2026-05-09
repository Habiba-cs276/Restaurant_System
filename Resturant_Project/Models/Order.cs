using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resturant_Project.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [ValidateNever]
        public ApplicationUser User { get; set; }
        [ValidateNever]
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
