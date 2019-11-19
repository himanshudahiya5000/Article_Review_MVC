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
    //Articles controller with security.
    [Authorize]
    public class ArticlesController : Controller
    {
        private readonly Article_Review_MVCDataContext _context;

        public ArticlesController(Article_Review_MVCDataContext context)
        {
            _context = context;
        }

        // GET: Articles
        //Gets all articles using  a lamda query.
        public IActionResult Index()
        {
            var article_Review_MVCDataContext = _context.Article.Include(a => a.Author).Include(a => a.Reviewer);
            return View( article_Review_MVCDataContext.ToList());
        }

        // GET: Articles/Details/5
        //Gets the details of the article using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article =  _context.Article
                .Include(a => a.Author)
                .Include(a => a.Reviewer)
                .FirstOrDefault(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        //Gets the Article create form.
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "Id", "Name");
            ViewData["ReviewerId"] = new SelectList(_context.Set<Reviewer>(), "Id", "Name");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds the article to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,AuthorId,ReviewerId,ReviewComment,Rating,Name")] Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Add(article);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "Id", "Name", article.AuthorId);
            ViewData["ReviewerId"] = new SelectList(_context.Set<Reviewer>(), "Id", "Name", article.ReviewerId);
            return View(article);
        }

        // GET: Articles/Edit/5
        //Get the article for edit using linq query.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = (from articles in _context.Article
                           where articles.Id == id
                           select articles).FirstOrDefault();
            if (article == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "Id", "Name", article.AuthorId);
            ViewData["ReviewerId"] = new SelectList(_context.Set<Reviewer>(), "Id", "Name", article.ReviewerId);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //Updates the article 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,AuthorId,ReviewerId,ReviewComment,Rating,Name")] Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Id))
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
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "Id", "Id", article.AuthorId);
            ViewData["ReviewerId"] = new SelectList(_context.Set<Reviewer>(), "Id", "Id", article.ReviewerId);
            return View(article);
        }

        // GET: Articles/Delete/5
        //Gets the Article for delete using a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = _context.Article
                .Include(a => a.Author)
                .Include(a => a.Reviewer)
                .FirstOrDefault(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        //Deletes the Article. Uses a linq query to select the article
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var article = (from articles in _context.Article
                           where articles.Id == id
                           select articles).FirstOrDefault();
            _context.Article.Remove(article);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the article exists using a ladma query.
        private bool ArticleExists(int id)
        {
            return _context.Article.Any(e => e.Id == id);
        }
    }
}
