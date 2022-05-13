using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WizLib_DataAccess.Data;
using WizLib_Model.Models;
using WizLib_Model.ViewModels;

namespace WizLib.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _applicationDb;
        public BookController(ApplicationDbContext applicationDb) => this._applicationDb = applicationDb;

        public IActionResult Index()
        {
            var books = _applicationDb.Books.Include(book => book.Publisher).ToList();
            return View(books);
        }

        public IActionResult Upsert(int? id)
        {
            var obj = new BookVM
            {
                PublisherList = _applicationDb.Publishers.Select(element => new SelectListItem
                    {
                        Text = element.Name,
                        Value = element.PublisherId.ToString()
                    }
                )
            };
            if (id == null)
            {
                return View(obj);
            }
            //this for edit
            obj.Book = _applicationDb.Books.FirstOrDefault(u => u.BookId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }



        public IActionResult Details(int? id)
        {
            var bookViewModel = new BookVM();
            if (id == null)
            {
                // Creation Process
                return View(bookViewModel);
            }
            bookViewModel.Book = _applicationDb.Books.Include(book => book.BookDetail).FirstOrDefault(book => book.BookId == id);
            return View(bookViewModel);
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(BookVM bookVm)
        {
            if (bookVm.Book.BookDetail.BookDetailId == 0)
            {
                await _applicationDb.BookDetails.AddAsync(bookVm.Book.BookDetail);
                await _applicationDb.SaveChangesAsync();

                var bookFromDb = await _applicationDb.Books.FirstOrDefaultAsync(b => b.BookId == bookVm.Book.BookId);
                bookFromDb.BookDetailsId = bookVm.Book.BookDetail.BookDetailId;
                await _applicationDb.SaveChangesAsync();
            }
            else
            {
                _applicationDb.BookDetails.Update(bookVm.Book.BookDetail);
                await _applicationDb.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BookVM bookVm)
        {
            if (bookVm.Book.BookId == 0)
            {
                await _applicationDb.AddAsync(bookVm.Book);
            }
            else
            {
                _applicationDb.Update(bookVm.Book);
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

        public IActionResult PlayGround()
        {
            var bookTemp = _applicationDb.Books.FirstOrDefault();
            if (bookTemp != null) bookTemp.Price = 100;

            var bookCollection = _applicationDb.Books;
            double totalPrice = 0;

            foreach (var book in bookCollection)
            {
                totalPrice += book.Price;
            }

            var bookList = _applicationDb.Books.ToList();
            foreach (var book in bookList)
            {
                totalPrice += book.Price;
            }

            var bookCollection2 = _applicationDb.Books;
            var bookCount1 = bookCollection2.Count();

            var bookCount2 = _applicationDb.Books.Count();

            return RedirectToAction("Index");
        }
        
    }
}



/*
 *  var bookTemp = _applicationDb.FirstOrDefault();
 *          bookTemp.Price = 100;
 *  var bookCollection = 
 *
 *
 *
 */