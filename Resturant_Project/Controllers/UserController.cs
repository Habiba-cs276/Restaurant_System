using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using NuGet.Protocol.Core.Types;
using Resturant_Project.Data;
using Resturant_Project.Models;



namespace Resturant_Project.Controllers
{
    public class UsersController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<ApplicationUser> _repository;

        public UsersController
        (
            UserManager<ApplicationUser> userManager,
            IRepository<ApplicationUser> repository
        )
        {
            _userManager = userManager;
            _repository = repository;
        }

        // ========================= Index =========================

        public async Task<IActionResult> Index()
        {
            var users = await _repository.GetAllAsync();

            return View("index",users);
        }

        // ========================= Details =========================

        public async Task<IActionResult> Details(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();

            return View(user);
        }

        // ========================= Create =========================

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserVM vm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = vm.FullName,
                    Email = vm.Email,
                };

                var result = await _userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                    return RedirectToAction("Index");

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }

            return View(vm);
        }

        // ========================= Edit =========================

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                var userFromDb = await _userManager.FindByIdAsync(user.Id);

                if (userFromDb == null)
                    return NotFound();

                userFromDb.UserName = user.UserName;
                userFromDb.Email = user.Email;
                userFromDb.PhoneNumber = user.PhoneNumber;

                var result = await _userManager.UpdateAsync(userFromDb);

                if (result.Succeeded)
                    return RedirectToAction("Index");

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }

            return View(user);
        }

        // ========================= Delete =========================

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
                return RedirectToAction("Index");

            return View("Delete", user);
        }


        #region Without Identity
        //ApplicationDbContext _context = new ApplicationDbContext();  
        //public IActionResult Index()
        //{
        //    List<ApplicationUser> users =_context.Users.ToList();

        //    return View("Index",users);
        //}
        //public IActionResult Create() 
        //{
        //return View("Create");
        //}
        //public IActionResult SaveCreate(ApplicationUser applicationUser) 
        //{
        //    if (ModelState.IsValid) 
        //    {
        //        _context.Users.Add(applicationUser);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");   

        //    }
        //    return View("Create",applicationUser);

        //}

        //public IActionResult Delete(int id) 
        //{
        //    ApplicationUser applicationUser = _context.Users.FirstOrDefault(u => u.Id == id);   
        //    if(applicationUser== null)
        //    {
        //        ModelState.AddModelError("", "User Not Found");
        //        return View();
        //    }
        //    _context.Users.Remove(applicationUser);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");   
        //}

        //public IActionResult Update(int id) 
        //{
        //ApplicationUser user = _context.Users.FirstOrDefault(i => i.Id == id);
        //    return View("Update", user);
        //}
        //public IActionResult SaveUpdate(int id, ApplicationUser applicationUser) 
        //{
        //    ApplicationUser user = _context.Users.FirstOrDefault(i => i.Id == id);
        //    user.UserName =applicationUser.UserName; 
        //    user.Password =applicationUser.Password;  
        //    user.Email=applicationUser.Email;   
        //    _context.SaveChanges(); 
        //    return RedirectToAction("Index");   

        //}
        #endregion

    }
}
