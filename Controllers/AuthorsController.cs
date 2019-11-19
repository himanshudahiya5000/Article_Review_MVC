using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Article_Review_MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace Article_Review_MVC.Controllers
{
    //Authors Controller using a security.
    [Authorize]
    public class AuthorsController : Controller
    {
        private readonly Article_Review_MVCDataContext _context;

        public AuthorsController(Article_Review_MVCDataContext context)
        {
            _context = context;
        }

        // GET: Authors
        //Gets  all the authors using a linq query
        public IActionResult Index()
        {
            return View((from authors in _context.Author select authors).ToList());
        }

        // GET: Authors/Details/5
        //Gets Author  details using a lamda query
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = _context.Author
                .FirstOrDefault(m => m.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // GET: Authors/Create
        //Gets the author create form.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds the author to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Email")] Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Add(author);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Edit/5
        //Gets the Author for edit using a linq query.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = (from authors in _context.Author
                          where authors.Id == id
                          select authors).FirstOrDefault();
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the author.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Email")] Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(author);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        //Gets the author for delete using a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = _context.Author
                .FirstOrDefault(m => m.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        //Deletes the author uses a linq query to select the author
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var author = (from authors in _context.Author
                          where authors.Id == id
                          select authors).FirstOrDefault();
            _context.Author.Remove(author);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the author  exists using a lamda query.
        private bool AuthorExists(int id)
        {
            return _context.Author.Any(e => e.Id == id);
        }
    }
}
