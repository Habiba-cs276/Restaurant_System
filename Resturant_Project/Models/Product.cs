using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_Project.Models
{
   
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        //[NotMapped]
        //public IFormFile? ImageFile { get; set; }  
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public List<OrderItem> OrderItems { get; set; }
        [ValidateNever]
        public List<ProductIngredient> ProductIngredients { get; set; }
    }
}
