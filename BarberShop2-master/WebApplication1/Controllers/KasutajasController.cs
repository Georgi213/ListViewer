﻿using System;
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
    public class KasutajasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KasutajasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kasutajas
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Index()
        {
              return View(await _context.Kasutaja.ToListAsync());
        }

        // GET: Kasutajas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kasutaja == null)
            {
                return NotFound();
            }

            var kasutaja = await _context.Kasutaja
                .FirstOrDefaultAsync(m => m.KasutajaID == id);
            if (kasutaja == null)
            {
                return NotFound();
            }

            return View(kasutaja);
        }

        // GET: Kasutajas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kasutajas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KasutajaID,Nimi,Vanus,Epost,Telefoninumber")] Kasutaja kasutaja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kasutaja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kasutaja);
        }

        // GET: Kasutajas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kasutaja == null)
            {
                return NotFound();
            }

            var kasutaja = await _context.Kasutaja.FindAsync(id);
            if (kasutaja == null)
            {
                return NotFound();
            }
            return View(kasutaja);
        }

        // POST: Kasutajas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KasutajaID,Nimi,Vanus,Epost,Telefoninumber")] Kasutaja kasutaja)
        {
            if (id != kasutaja.KasutajaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kasutaja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KasutajaExists(kasutaja.KasutajaID))
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
            return View(kasutaja);
        }

        // GET: Kasutajas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kasutaja == null)
            {
                return NotFound();
            }

            var kasutaja = await _context.Kasutaja
                .FirstOrDefaultAsync(m => m.KasutajaID == id);
            if (kasutaja == null)
            {
                return NotFound();
            }

            return View(kasutaja);
        }

        // POST: Kasutajas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kasutaja == null)
            {
                return Problem("Entity set 'WebApplication1Context.Kasutaja'  is null.");
            }
            var kasutaja = await _context.Kasutaja.FindAsync(id);
            if (kasutaja != null)
            {
                _context.Kasutaja.Remove(kasutaja);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KasutajaExists(int id)
        {
          return _context.Kasutaja.Any(e => e.KasutajaID == id);
        }
    }
}
