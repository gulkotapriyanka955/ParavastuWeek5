using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParavastuWeek5.Models;

namespace ParavastuWeek5.Controllers
{
    public class RepresentativesController : Controller
    {
        private readonly NPGoldContext _context;

        public RepresentativesController(NPGoldContext context)
        {
            _context = context;
        }

        // GET: Representatives
        public async Task<IActionResult> Index()
        {
              return _context.Representatives != null ? 
                          View(await _context.Representatives.ToListAsync()) :
                          Problem("Entity set 'NPGoldContext.Representatives'  is null.");
        }

        // GET: Representatives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Representatives == null)
            {
                return NotFound();
            }

            var representative = await _context.Representatives
                .FirstOrDefaultAsync(m => m.RepId == id);
            if (representative == null)
            {
                return NotFound();
            }

            return View(representative);
        }

        // GET: Representatives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Representatives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RepId,RepFirstName,RepLastName,RepSalary")] Representative representative)
        {
            if (ModelState.IsValid)
            {
                _context.Add(representative);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(representative);
        }

        // GET: Representatives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Representatives == null)
            {
                return NotFound();
            }

            var representative = await _context.Representatives.FindAsync(id);
            if (representative == null)
            {
                return NotFound();
            }
            return View(representative);
        }

        // POST: Representatives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RepId,RepFirstName,RepLastName,RepSalary")] Representative representative)
        {
            if (id != representative.RepId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(representative);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepresentativeExists(representative.RepId))
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
            return View(representative);
        }

        // GET: Representatives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Representatives == null)
            {
                return NotFound();
            }

            var representative = await _context.Representatives
                .FirstOrDefaultAsync(m => m.RepId == id);
            if (representative == null)
            {
                return NotFound();
            }

            return View(representative);
        }

        // POST: Representatives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Representatives == null)
            {
                return Problem("Entity set 'NPGoldContext.Representatives'  is null.");
            }
            var representative = await _context.Representatives.FindAsync(id);
            if (representative != null)
            {
                _context.Representatives.Remove(representative);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepresentativeExists(int id)
        {
          return (_context.Representatives?.Any(e => e.RepId == id)).GetValueOrDefault();
        }
    }
}
