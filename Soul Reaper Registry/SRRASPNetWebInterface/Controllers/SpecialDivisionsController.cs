using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Models;

namespace SRRASPNetWebInterface.Controllers
{
    public class SpecialDivisionsController : Controller
    {
        private readonly SRRContext _context;

        public SpecialDivisionsController(SRRContext context)
        {
            _context = context;
        }

        // GET: SpecialDivisions
        public async Task<IActionResult> Index()
        {
            var sRRContext = _context.SpecialDivision.Include(s => s.Leader);
            return View(await sRRContext.ToListAsync());
        }

        // GET: SpecialDivisions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialDivision = await _context.SpecialDivision
                .Include(s => s.Leader)
                .FirstOrDefaultAsync(m => m.SDId == id);
            if (specialDivision == null)
            {
                return NotFound();
            }

            return View(specialDivision);
        }

        // GET: SpecialDivisions/Create
        public IActionResult Create()
        {
            ViewData["LeaderId"] = new SelectList(_context.SoulReaper, "SRId", "FirstName");
            return View();
        }

        // POST: SpecialDivisions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SDId,Name,LeaderId,Description")] SpecialDivision specialDivision)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialDivision);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeaderId"] = new SelectList(_context.SoulReaper, "SRId", "FirstName", specialDivision.LeaderId);
            return View(specialDivision);
        }

        // GET: SpecialDivisions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialDivision = await _context.SpecialDivision.FindAsync(id);
            if (specialDivision == null)
            {
                return NotFound();
            }
            ViewData["LeaderId"] = new SelectList(_context.SoulReaper, "SRId", "FirstName", specialDivision.LeaderId);
            return View(specialDivision);
        }

        // POST: SpecialDivisions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SDId,Name,LeaderId,Description")] SpecialDivision specialDivision)
        {
            if (id != specialDivision.SDId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialDivision);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialDivisionExists(specialDivision.SDId))
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
            ViewData["LeaderId"] = new SelectList(_context.SoulReaper, "SRId", "FirstName", specialDivision.LeaderId);
            return View(specialDivision);
        }

        // GET: SpecialDivisions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialDivision = await _context.SpecialDivision
                .Include(s => s.Leader)
                .FirstOrDefaultAsync(m => m.SDId == id);
            if (specialDivision == null)
            {
                return NotFound();
            }

            return View(specialDivision);
        }

        // POST: SpecialDivisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialDivision = await _context.SpecialDivision.FindAsync(id);
            _context.SpecialDivision.Remove(specialDivision);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialDivisionExists(int id)
        {
            return _context.SpecialDivision.Any(e => e.SDId == id);
        }
    }
}
