using Microsoft.AspNetCore.Mvc;
using Resturant_Project.Data;
using Resturant_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;



namespace Resturant_Project.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();  
        public IActionResult Index()
        {
            List<ApplicationUser> users =_context.Users.ToList();

            return View("Index",users);
        }
        public IActionResult Create() 
        {
        return View("Create");
        }
        public IActionResult SaveCreate(ApplicationUser applicationUser) 
        {
            if (ModelState.IsValid) 
            {
                _context.Users.Add(applicationUser);
                _context.SaveChanges();
                return RedirectToAction("Index");   
            
            }
            return View("Create",applicationUser);
        
        }

        public IActionResult Delete(int id) 
        {
            ApplicationUser applicationUser = _context.Users.FirstOrDefault(u => u.Id == id);   
            if(applicationUser== null)
            {
                ModelState.AddModelError("", "User Not Found");
                return View();
            }
            _context.Users.Remove(applicationUser);
            _context.SaveChanges();
            return RedirectToAction("Index");   
        }
    
        public IActionResult Update(int id) 
        {
        ApplicationUser user = _context.Users.FirstOrDefault(i => i.Id == id);
            return View("Update", user);
        }
        public IActionResult SaveUpdate(int id, ApplicationUser applicationUser) 
        {
            ApplicationUser user = _context.Users.FirstOrDefault(i => i.Id == id);
            user.UserName =applicationUser.UserName; 
            user.Password =applicationUser.Password;  
            user.Email=applicationUser.Email;   
            _context.SaveChanges(); 
            return RedirectToAction("Index");   

        }
    }
}
