using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab4_2.Data;
using Lab4_2.Models;

namespace Lab4_2.Controllers
{
    public class BeersController : Controller
    {
        private readonly Lab4_2Context _context;

        public BeersController(Lab4_2Context context)
        {
            _context = context;
        }

        // GET: Beers
        /*public async Task<IActionResult> Index()
        {
              return _context.Beer != null ? 
                          View(await _context.Beer.ToListAsync()) :
                          Problem("Entity set 'Lab4_2Context.Beer'  is null.");
        }*/

        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Title" : "";
            ViewData["DateSortParm"] = sortOrder == "Alchool" ? "Description" : "Alchool";
            var students = from s in _context.Beer
                           select s;
            switch (sortOrder)
            {
                case "Title":
                    students = students.OrderByDescending(s => s.Title);
                    break;
                case "Alchool":
                    students = students.OrderBy(s => s.Alchool);
                    break;
                case "Description":
                    students = students.OrderByDescending(s => s.Description);
                    break;
                default:
                    students = students.OrderBy(s => s.Country);
                    break;
            }
            return View(await students.AsNoTracking().ToListAsync());
        }

        // GET: Beers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Beer == null)
            {
                return NotFound();
            }

            var beer = await _context.Beer
                .FirstOrDefaultAsync(m => m.ID == id);
            if (beer == null)
            {
                return NotFound();
            }

            return View(beer);
        }

        // GET: Beers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Alchool,Description,Country")] Beer beer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beer);
        }

        // GET: Beers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Beer == null)
            {
                return NotFound();
            }

            var beer = await _context.Beer.FindAsync(id);
            if (beer == null)
            {
                return NotFound();
            }
            return View(beer);
        }

        // POST: Beers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Alchool,Description,Country")] Beer beer)
        {
            if (id != beer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeerExists(beer.ID))
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
            return View(beer);
        }

        // GET: Beers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Beer == null)
            {
                return NotFound();
            }

            var beer = await _context.Beer
                .FirstOrDefaultAsync(m => m.ID == id);
            if (beer == null)
            {
                return NotFound();
            }

            return View(beer);
        }

        // POST: Beers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Beer == null)
            {
                return Problem("Entity set 'Lab4_2Context.Beer'  is null.");
            }
            var beer = await _context.Beer.FindAsync(id);
            if (beer != null)
            {
                _context.Beer.Remove(beer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeerExists(int id)
        {
          return (_context.Beer?.Any(e => e.ID == id)).GetValueOrDefault();
        }

    }
}
