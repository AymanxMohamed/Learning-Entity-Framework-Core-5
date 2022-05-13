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
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _applicationDb;
        public AuthorController(ApplicationDbContext applicationDb) => this._applicationDb = applicationDb;

        public IActionResult Index()
        {
            var authors = _applicationDb.Authors.ToList();
            return View(authors);
        }

        public IActionResult Upsert(int? id)
        {
            var obj = new Author();
            if (id == null)
            {
                return View(obj);
            }
            //this for edit
            obj = _applicationDb.Authors.FirstOrDefault(u => u.AuthorId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Author author)
        {
            if(!ModelState.IsValid) return View(author);
            if (author.AuthorId == 0)
            {
                await _applicationDb.AddAsync(author);
            }
            else
            {
                _applicationDb.Update(author);
            }
            await _applicationDb.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var author = await _applicationDb.Authors.FirstOrDefaultAsync(auth => auth.AuthorId == id);
            _applicationDb.Remove(author);
            await _applicationDb.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
    }
}
