using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;

namespace Resturant_Project.Models
{
   
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ValidateNever]
        public List<Product> Products { get; set; } = new();
    }
}
