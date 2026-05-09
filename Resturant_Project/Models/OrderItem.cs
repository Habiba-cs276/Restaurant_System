using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Resturant_Project.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        [ValidateNever]
        public Order Order { get; set; }
        [ValidateNever]
        public Product Product { get; set; }
    }
}
