using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Resturant_Project.Models
{
    public class ProductIngredient
    {
        public int Id { get; set; } 
        public int ProductId { get; set; }
        public int IngredientId { get; set; }
        [ValidateNever]

        public Product Product { get; set; }
        [ValidateNever]
        public Ingredient Ingredient { get; set; }
    }
}
