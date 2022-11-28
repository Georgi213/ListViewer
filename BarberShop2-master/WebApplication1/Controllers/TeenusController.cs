using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TeenusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeenusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Teenus
        public async Task<IActionResult> Index()
        {
              return View(await _context.Teenus.ToListAsync());
        }

        // GET: Teenus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Teenus == null)
            {
                return NotFound();
            }

            var teenus = await _context.Teenus
                .FirstOrDefaultAsync(m => m.TeenusID == id);
            if (teenus == null)
            {
                return NotFound();
            }

            return View(teenus);
        }

        // GET: Teenus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeenusID,Nimetus,Hind,Kestvus")] Teenus teenus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teenus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teenus);
        }

        // GET: Teenus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Teenus == null)
            {
                return NotFound();
            }

            var teenus = await _context.Teenus.FindAsync(id);
            if (teenus == null)
            {
                return NotFound();
            }
            return View(teenus);
        }

        // POST: Teenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeenusID,Nimetus,Hind,Kestvus")] Teenus teenus)
        {
            if (id != teenus.TeenusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teenus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeenusExists(teenus.TeenusID))
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
            return View(teenus);
        }

        // GET: Teenus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Teenus == null)
            {
                return NotFound();
            }

            var teenus = await _context.Teenus
                .FirstOrDefaultAsync(m => m.TeenusID == id);
            if (teenus == null)
            {
                return NotFound();
            }

            return View(teenus);
        }

        // POST: Teenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Teenus == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Teenus'  is null.");
            }
            var teenus = await _context.Teenus.FindAsync(id);
            if (teenus != null)
            {
                _context.Teenus.Remove(teenus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeenusExists(int id)
        {
          return _context.Teenus.Any(e => e.TeenusID == id);
        }
    }
}
