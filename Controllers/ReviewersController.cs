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
    //Reviewers controller with security.
    [Authorize]
    public class ReviewersController : Controller
    {
        private readonly Article_Review_MVCDataContext _context;

        public ReviewersController(Article_Review_MVCDataContext context)
        {
            _context = context;
        }

        // GET: Reviewers
        //Gets all reviewers using a linq query
        public IActionResult Index()
        {
            return View( (from reviewers in _context.Reviewer select reviewers).ToList());
        }

        // GET: Reviewers/Details/5
        //Gets the details using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewer =  _context.Reviewer
                .FirstOrDefault(m => m.Id == id);
            if (reviewer == null)
            {
                return NotFound();
            }

            return View(reviewer);
        }

        // GET: Reviewers/Create
        //Gets the create reviewer form.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reviewers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds a the reviewer to databse.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Email")] Reviewer reviewer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reviewer);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(reviewer);
        }

        // GET: Reviewers/Edit/5
        //Gets the reviewer for edit using  a linq query.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewer = (from reviewrs in _context.Reviewer
                            where reviewrs.Id == id select reviewrs).FirstOrDefault();
            if (reviewer == null)
            {
                return NotFound();
            }
            return View(reviewer);
        }

        // POST: Reviewers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the reviewer 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Email")] Reviewer reviewer)
        {
            if (id != reviewer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviewer);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewerExists(reviewer.Id))
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
            return View(reviewer);
        }

        // GET: Reviewers/Delete/5
        //Gets the reviewer for delete using a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewer =  _context.Reviewer
                .FirstOrDefault(m => m.Id == id);
            if (reviewer == null)
            {
                return NotFound();
            }

            return View(reviewer);
        }

        // POST: Reviewers/Delete/5
        //Deletes the reviewer uses a linq query to select the reviewer
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var reviewer = (from reviewrs in _context.Reviewer
                            where reviewrs.Id == id
                            select reviewrs).FirstOrDefault();
            _context.Reviewer.Remove(reviewer);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the reviewer exists using a lamda query.
        private bool ReviewerExists(int id)
        {
            return _context.Reviewer.Any(e => e.Id == id);
        }
    }
}
