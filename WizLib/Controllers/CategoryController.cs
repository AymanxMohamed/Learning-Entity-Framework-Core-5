using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WizLib_DataAccess.Data;
using WizLib_Model.Models;

namespace WizLib.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _applicationDb;
        public CategoryController(ApplicationDbContext applicationDb)
        {
            this._applicationDb = applicationDb;
        }
        public IActionResult Index()
        {
            var categories = _applicationDb.Categories.ToList();
            return View(categories);
        }

        public IActionResult Upsert(int? id)
        {
            var category = new Category();
            if (id == null)
            {
                // return the create view
                return View(category);
            }
            // This means that it's edit
            category = _applicationDb.Categories.FirstOrDefault(cat => cat.Category_Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category category)
        {
            if (!ModelState.IsValid) return View(category);
            if (category.Category_Id == 0)
            {
                await _applicationDb.Categories.AddAsync(category);
            }
            else
            {
                _applicationDb.Categories.Update(category);
            }
            await _applicationDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            var cat = _applicationDb.Categories.FirstOrDefaultAsync(cat => cat.Category_Id == id);
            _applicationDb.Categories.Remove(await cat);
            await _applicationDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple2()
        {
            List<Category> catList = new ();
            for (var i = 0; i < 2; i++)
            {
                catList.Add(new Category { Name= Guid.NewGuid().ToString() });
            }

            await _applicationDb.Categories.AddRangeAsync(catList);
            await _applicationDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple5()
        {
            var catList = new List<Category>();
            for (var i = 0; i < 4; i++)
            {
                catList.Add(new Category { Name = Guid.NewGuid().ToString() });
            }

            await _applicationDb.Categories.AddRangeAsync(catList);
            await _applicationDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            var catList =
                _applicationDb.Categories.OrderByDescending(u => u.Category_Id).Take(2).ToList();
                _applicationDb.Categories.RemoveRange(catList);
                _applicationDb.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple5()
        {
            var catList =
                _applicationDb.Categories.OrderByDescending(u => u.Category_Id).Take(5).ToList();
            _applicationDb.Categories.RemoveRange(catList);
            _applicationDb.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



    }
}
