using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Resturant_Project.Data;
using Resturant_Project.Models;
using Resturant_Project.Models.Specifications;
using System.Threading.Tasks;

namespace Resturant_Project.Controllers
{
    public class OrderController : Controller
    {
        private IRepository<Order> _repository;
        private readonly IRepository<Product> _productRepo;
        public OrderController(IRepository<Order> repo, IRepository<Product> productRepo)
        {
            _repository = repo;
            _productRepo = productRepo;
        }
        public async Task<IActionResult> Index()
        {  return View("Index", await _repository.GetAllAsync());
        }
        
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var products = await _productRepo.GetAllAsync();

            ViewBag.Products = products.Select(p => new SelectListItem
            {
                Value = p.ProductId.ToString(),
                Text = p.Name
            }).ToList();
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> SaveCreate(Order order, int[] selectedProductIds)
        {
            if (selectedProductIds != null && selectedProductIds.Length > 0) 
            {
                foreach (var productId in selectedProductIds)
                {
                    Product P = await _productRepo.GetByIdAsync(productId);
                    decimal price = P.Price;
                    order.OrderItems.Add(new OrderItem
                    {
                        ProductId = productId,
                        Quantity = 1,
                        Price = price
                    });
                }
            }
            if (ModelState.IsValid)
            {
               await _repository.AddAsync(order);
                _repository.Save();
                return RedirectToAction("Index");
            }
            var products = await _productRepo.GetAllAsync();


            ViewBag.Products = products.Select(p => new SelectListItem
            {
                Value = p.ProductId.ToString(),
                Text = p.Name
            }).ToList();

            ViewBag.Products = products.Select(p => new SelectListItem
            {
                Value = p.ProductId.ToString(),
                Text = p.Name
            }).ToList(); 
            return View("Create", order);
        }
   
        public async Task<IActionResult> Delete(int id) 
        {
           await _repository.DeleteAsync(id);
            _repository.Save();
            return RedirectToAction("Index");   
        }
        public async Task<IActionResult> Details(int id) 
        {
            BaseSpecifications<Order> specification = new BaseSpecifications<Order>();
            specification.AddInclude(i=>i.User);
            specification.AddIncludeString("OrderItems.Product");

            return View("Details", await _repository.GetByIdWithSpecAsync(id, specification));
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View("Edit", await _repository.GetByIdAsync(id));
        }
        public async Task<IActionResult> SaveEdit(Order order) 
        {
            if (ModelState.IsValid) { 
            await _repository.UpdateAsync(order);
                  _repository.Save();
                return RedirectToAction("Index");
            }
            return View("Edit", order);

        }
    }
}
