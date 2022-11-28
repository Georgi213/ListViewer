using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TootajasController : Controller
    {
        public  ApplicationDbContext _context;

        public TootajasController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Tootajas
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tootaja.ToListAsync());
        }

        // GET: Tootajas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tootaja == null)
            {
                return NotFound();
            }

            var tootaja = await _context.Tootaja
                .FirstOrDefaultAsync(m => m.TootajaID == id);
            if (tootaja == null)
            {
                return NotFound();
            }

            return View(tootaja);
        }

        // GET: Tootajas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tootajas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TootajaID,Nimi,Vanus,Epost,Telefoninumber,haridus")] Tootaja tootaja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tootaja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tootaja);
        }

        // GET: Tootajas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tootaja == null)
            {
                return NotFound();
            }

            var tootaja = await _context.Tootaja.FindAsync(id);
            if (tootaja == null)
            {
                return NotFound();
            }
            return View(tootaja);
        }

        // POST: Tootajas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TootajaID,Nimi,Vanus,Epost,Telefoninumber,haridus")] Tootaja tootaja)
        {
            if (id != tootaja.TootajaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tootaja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TootajaExists(tootaja.TootajaID))
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
            return View(tootaja);
        }

        // GET: Tootajas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tootaja == null)
            {
                return NotFound();
            }

            var tootaja = await _context.Tootaja
                .FirstOrDefaultAsync(m => m.TootajaID == id);
            if (tootaja == null)
            {
                return NotFound();
            }

            return View(tootaja);
        }

        // POST: Tootajas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tootaja == null)
            {
                return Problem("Entity set 'WebApplication1Context.Tootaja'  is null.");
            }
            var tootaja = await _context.Tootaja.FindAsync(id);
            if (tootaja != null)
            {
                _context.Tootaja.Remove(tootaja);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TootajaExists(int id)
        {
          return _context.Tootaja.Any(e => e.TootajaID == id);
        }
    }
}
