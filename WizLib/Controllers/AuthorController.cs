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
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _applicationDb;
        public PublisherController(ApplicationDbContext applicationDb) => this._applicationDb = applicationDb;

        public IActionResult Index() => View(_applicationDb.Publishers.ToList());

        public IActionResult Upsert(int? id)
        {
            var obj = new Publisher();
            if (id == null)
            {
                return View(obj);
            }
            //this for edit
            obj = _applicationDb.Publishers.FirstOrDefault(u => u.PublisherId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Publisher publisher)
        {
            if(!ModelState.IsValid) return View(publisher);
            if (publisher.PublisherId == 0)
            {
                await _applicationDb.AddAsync(publisher);
            }
            else
            {
                _applicationDb.Update(publisher);
            }
            await _applicationDb.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var publisher = await _applicationDb.Publishers.FirstOrDefaultAsync(publisher => publisher.PublisherId == id);
            _applicationDb.Remove(publisher);
            await _applicationDb.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
    }
}
