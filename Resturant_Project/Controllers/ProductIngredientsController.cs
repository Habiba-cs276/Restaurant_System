using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Resturant_Project.Data;
using Resturant_Project.Models;

namespace Resturant_Project.Controllers
{
    public class ProductIngredientsController : Controller
    {
        private IRepository<ProductIngredient> _repository;
        public ProductIngredientsController(IRepository<ProductIngredient> repo)
        {
            _repository = repo;

        }

        //// GET: ProductIngredients
        //public async Task<IActionResult> Index()
        //{
        //    var applicationDbContext = _context.ProductIngredients.Include(p => p.Ingredient).Include(p => p.Product);
        //    return View(await applicationDbContext.ToListAsync());
        //}

        //// GET: ProductIngredients/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var productIngredient = await _context.ProductIngredients
        //        .Include(p => p.Ingredient)
        //        .Include(p => p.Product)
        //        .FirstOrDefaultAsync(m => m.ProductId == id);
        //    if (productIngredient == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(productIngredient);
        //}

        //// GET: ProductIngredients/Create
        //public IActionResult Create()
        //{
        //    ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId");
        //    ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
        //    return View();
        //}

        //// POST: ProductIngredients/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,ProductId,IngredientId")] ProductIngredient productIngredient)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(productIngredient);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", productIngredient.IngredientId);
        //    ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", productIngredient.ProductId);
        //    return View(productIngredient);
        //}

        //// GET: ProductIngredients/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var productIngredient = await _context.ProductIngredients.FindAsync(id);
        //    if (productIngredient == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", productIngredient.IngredientId);
        //    ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", productIngredient.ProductId);
        //    return View(productIngredient);
        //}

        //// POST: ProductIngredients/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,IngredientId")] ProductIngredient productIngredient)
        //{
        //    if (id != productIngredient.ProductId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(productIngredient);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductIngredientExists(productIngredient.ProductId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", productIngredient.IngredientId);
        //    ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", productIngredient.ProductId);
        //    return View(productIngredient);
        //}

        //// GET: ProductIngredients/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var productIngredient = await _context.ProductIngredients
        //        .Include(p => p.Ingredient)
        //        .Include(p => p.Product)
        //        .FirstOrDefaultAsync(m => m.ProductId == id);
        //    if (productIngredient == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(productIngredient);
        //}

        //// POST: ProductIngredients/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var productIngredient = await _context.ProductIngredients.FindAsync(id);
        //    if (productIngredient != null)
        //    {
        //        _context.ProductIngredients.Remove(productIngredient);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProductIngredientExists(int id)
        //{
        //    return _context.ProductIngredients.Any(e => e.ProductId == id);
        //}
    }
}
