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
    public class SoulReapersController : Controller
    {
        private readonly SRRContext _context;

        public SoulReapersController(SRRContext context)
        {
            _context = context;
        }

        // GET: SoulReapers
        public async Task<IActionResult> Index()
        {
            var sRRContext = _context.SoulReaper.Include(s => s.Division).Include(s => s.SpecialDivision).Include(s => s.WeaponPowers);
            return View(await sRRContext.ToListAsync());
        }

        // GET: SoulReapers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soulReaper = await _context.SoulReaper
                .Include(s => s.Division)
                .Include(s => s.SpecialDivision)
                .Include(s => s.WeaponPowers)
                .FirstOrDefaultAsync(m => m.SRId == id);
            if (soulReaper == null)
            {
                return NotFound();
            }

            return View(soulReaper);
        }

        // GET: SoulReapers/Create
        public IActionResult Create()
        {
            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionNumber", "Name");
            ViewData["SpecialDivisionId"] = new SelectList(_context.SpecialDivision, "SDId", "Name");
            ViewData["WeaponPowerId"] = new SelectList(_context.WeaponPower, "WPId", "FirstForm");
            return View();
        }

        // POST: SoulReapers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SRId,FirstName,LastName,EnrollDate,Available,DivisionId,SpecialDivisionId,WeaponName,WeaponPowerId,Description")] SoulReaper soulReaper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soulReaper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionNumber", "Name", soulReaper.DivisionId);
            ViewData["SpecialDivisionId"] = new SelectList(_context.SpecialDivision, "SDId", "Name", soulReaper.SpecialDivisionId);
            ViewData["WeaponPowerId"] = new SelectList(_context.WeaponPower, "WPId", "FirstForm", soulReaper.WeaponPowerId);
            return View(soulReaper);
        }

        // GET: SoulReapers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soulReaper = await _context.SoulReaper.FindAsync(id);
            if (soulReaper == null)
            {
                return NotFound();
            }
            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionNumber", "Name", soulReaper.DivisionId);
            ViewData["SpecialDivisionId"] = new SelectList(_context.SpecialDivision, "SDId", "Name", soulReaper.SpecialDivisionId);
            ViewData["WeaponPowerId"] = new SelectList(_context.WeaponPower, "WPId", "FirstForm", soulReaper.WeaponPowerId);
            return View(soulReaper);
        }

        // POST: SoulReapers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SRId,FirstName,LastName,EnrollDate,Available,DivisionId,SpecialDivisionId,WeaponName,WeaponPowerId,Description")] SoulReaper soulReaper)
        {
            if (id != soulReaper.SRId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soulReaper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoulReaperExists(soulReaper.SRId))
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
            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionNumber", "Name", soulReaper.DivisionId);
            ViewData["SpecialDivisionId"] = new SelectList(_context.SpecialDivision, "SDId", "Name", soulReaper.SpecialDivisionId);
            ViewData["WeaponPowerId"] = new SelectList(_context.WeaponPower, "WPId", "FirstForm", soulReaper.WeaponPowerId);
            return View(soulReaper);
        }

        // GET: SoulReapers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soulReaper = await _context.SoulReaper
                .Include(s => s.Division)
                .Include(s => s.SpecialDivision)
                .Include(s => s.WeaponPowers)
                .FirstOrDefaultAsync(m => m.SRId == id);
            if (soulReaper == null)
            {
                return NotFound();
            }

            return View(soulReaper);
        }

        // POST: SoulReapers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var soulReaper = await _context.SoulReaper.FindAsync(id);
            _context.SoulReaper.Remove(soulReaper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoulReaperExists(int id)
        {
            return _context.SoulReaper.Any(e => e.SRId == id);
        }
    }
}
