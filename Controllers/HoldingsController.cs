using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockCSV.Data;
using StockCSV.Models;

namespace StockCSV.Controllers
{
    public class HoldingsController : Controller
    {
        private readonly StockCSVContext _context;

        public HoldingsController(StockCSVContext context)
        {
            _context = context;
        }

        // GET: Holdings
        public async Task<IActionResult> Index()
        {
              return _context.Holding != null ? 
                          View(await _context.Holding.ToListAsync()) :
                          Problem("Entity set 'StockCSVContext.Holding'  is null.");
        }

        // GET: Holdings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Holding == null)
            {
                return NotFound();
            }

            var holding = await _context.Holding
                .FirstOrDefaultAsync(m => m.Id == id);
            if (holding == null)
            {
                return NotFound();
            }

            return View(holding);
        }

        // GET: Holdings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Holdings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Units,AVGPrice,PurchaseDate")] Holding holding)
        {
            if (ModelState.IsValid)
            {
                _context.Add(holding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(holding);
        }

        // GET: Holdings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Holding == null)
            {
                return NotFound();
            }

            var holding = await _context.Holding.FindAsync(id);
            if (holding == null)
            {
                return NotFound();
            }
            return View(holding);
        }

        // POST: Holdings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Units,AVGPrice,PurchaseDate")] Holding holding)
        {
            if (id != holding.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(holding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoldingExists(holding.Id))
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
            return View(holding);
        }

        // GET: Holdings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Holding == null)
            {
                return NotFound();
            }

            var holding = await _context.Holding
                .FirstOrDefaultAsync(m => m.Id == id);
            if (holding == null)
            {
                return NotFound();
            }

            return View(holding);
        }

        // POST: Holdings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Holding == null)
            {
                return Problem("Entity set 'StockCSVContext.Holding'  is null.");
            }
            var holding = await _context.Holding.FindAsync(id);
            if (holding != null)
            {
                _context.Holding.Remove(holding);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoldingExists(int id)
        {
          return (_context.Holding?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
