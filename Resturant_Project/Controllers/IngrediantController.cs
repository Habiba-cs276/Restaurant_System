using Microsoft.AspNetCore.Mvc;
using Resturant_Project.Models;
using Resturant_Project.Models.Specifications;
using System.Threading.Tasks;

namespace Resturant_Project.Controllers
{
    public class IngrediantController : Controller
    {
        private IRepository<Ingredient> _repository;
        public IngrediantController(IRepository<Ingredient>repo) 
        {
            _repository = repo;
        
        }
        public async Task<IActionResult> Index()
        {
            return View("Index",await _repository.GetAllAsync());
        }
        public IActionResult Create()
        {
        return View("Create");  
        }
        public IActionResult SaveCreate(Ingredient IngredFromReq)
        {
            if (ModelState.IsValid) {
                _repository.AddAsync(IngredFromReq);
                _repository.Save();
                return RedirectToAction("Index");   
            }
            return View("Create", IngredFromReq);
        }
        public async Task Delete(int id) 
        {
          await  _repository.DeleteAsync(id);
            _repository.Save();
        }
        
        public async Task <IActionResult >Edit(int id)
        {
            return View("Edit", await _repository.GetByIdAsync(id));

        }
        public async Task<IActionResult> Details(int id) {
            BaseSpecifications<Ingredient>specification = new BaseSpecifications<Ingredient>();
            specification.AddIncludeString("ProductIngredient.Product");            
            return View("ShowDetails", await _repository.GetByIdWithSpecAsync(id,specification));
        }
        //using  Specification Pattern 
        public async Task<IActionResult> IndexContainsA()
        {
            return View("Index", await _repository.GetAllWithSpecAsync
            (new BaseSpecifications<Ingredient>(i => i.Name.Contains("A"))));
        }

    }
}
