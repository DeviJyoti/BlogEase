using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogEase.Models;

namespace BlogEase.Controllers
{
    public class ContentClassesController : Controller
    {
        private readonly BlogDBContext _context;

        public ContentClassesController()
        {
            _context = new BlogDBContext();
        }

        // GET: ContentClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContentClasses.ToListAsync());
        }

        // GET: ContentClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentClass = await _context.ContentClasses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contentClass == null)
            {
                return NotFound();
            }

            return View(contentClass);
        }

        // GET: ContentClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContentClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content")] ContentClass contentClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contentClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contentClass);
        }

        // GET: ContentClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentClass = await _context.ContentClasses.FindAsync(id);
            if (contentClass == null)
            {
                return NotFound();
            }
            return View(contentClass);
        }

        // POST: ContentClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content")] ContentClass contentClass)
        {
            if (id != contentClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contentClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentClassExists(contentClass.Id))
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
            return View(contentClass);
        }

        // GET: ContentClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentClass = await _context.ContentClasses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contentClass == null)
            {
                return NotFound();
            }

            return View(contentClass);
        }

        // POST: ContentClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contentClass = await _context.ContentClasses.FindAsync(id);
            if (contentClass != null)
            {
                _context.ContentClasses.Remove(contentClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContentClassExists(int id)
        {
            return _context.ContentClasses.Any(e => e.Id == id);
        }
    }
}
