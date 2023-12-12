using System;
using Library.API.Data.Models;
using Library.API.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class BooksController : Controller
    {
        public readonly IBookService _service;
        public BooksController(IBookService service)
        {
            _service = service;
        }

        // GET: Shopping
        public ActionResult Index()
        {
            var result = _service.GetAll();
            return View(result);
        }

        // GET: Shopping/Details/5
        public ActionResult Details(Guid id)
        {
            var result = _service.GetById(id);
            if(result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // GET: Shopping/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shopping/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book item)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                _service.Add(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: Shopping/Delete/5
        public ActionResult Delete(Guid id)
        {
            var result = _service.GetById(id);
            return View(result);
        }

        // POST: Shopping/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _service.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}