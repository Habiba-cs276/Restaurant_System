using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturant_Project.Data;
using Resturant_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Resturant_Project.Controllers
{
    public class OrderController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public IActionResult Index()
        {
            List<Order> users = _context.Orders.ToList();

            return View("Index", users);
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        public IActionResult SaveCreate(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View("Create", order);

        }
    }
}
