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
    public class DivisionsController : Controller
    {
        private readonly SRRContext _context;

        public DivisionsController(SRRContext context)
        {
            _context = context;
        }

        // GET: Divisions
        public async Task<IActionResult> Index()
        {
            var sRRContext = _context.Division.Include(d => d.Captain).Include(d => d.Lieutenant);
            return View(await sRRContext.ToListAsync());
        }

        // GET: Divisions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var division = await _context.Division
                .Include(d => d.Captain)
                .Include(d => d.Lieutenant)
                .FirstOrDefaultAsync(m => m.DivisionNumber == id);
            if (division == null)
            {
                return NotFound();
            }

            return View(division);
        }

        // GET: Divisions/Create
        public IActionResult Create()
        {
            ViewData["CaptainId"] = new SelectList(_context.SoulReaper, "SRId", "FirstName");
            ViewData["LieutenantId"] = new SelectList(_context.SoulReaper, "SRId", "FirstName");
            return View();
        }

        // POST: Divisions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DivisionNumber,Name,CaptainId,LieutenantId,Description")] Division division)
        {
            if (ModelState.IsValid)
            {
                _context.Add(division);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CaptainId"] = new SelectList(_context.SoulReaper, "SRId", "FirstName", division.CaptainId);
            ViewData["LieutenantId"] = new SelectList(_context.SoulReaper, "SRId", "FirstName", division.LieutenantId);
            return View(division);
        }

        // GET: Divisions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var division = await _context.Division.FindAsync(id);
            if (division == null)
            {
                return NotFound();
            }
            ViewData["CaptainId"] = new SelectList(_context.SoulReaper, "SRId", "FirstName", division.CaptainId);
            ViewData["LieutenantId"] = new SelectList(_context.SoulReaper, "SRId", "FirstName", division.LieutenantId);
            return View(division);
        }

        // POST: Divisions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DivisionNumber,Name,CaptainId,LieutenantId,Description")] Division division)
        {
            if (id != division.DivisionNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(division);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DivisionExists(division.DivisionNumber))
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
            ViewData["CaptainId"] = new SelectList(_context.SoulReaper, "SRId", "FirstName", division.CaptainId);
            ViewData["LieutenantId"] = new SelectList(_context.SoulReaper, "SRId", "FirstName", division.LieutenantId);
            return View(division);
        }

        // GET: Divisions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var division = await _context.Division
                .Include(d => d.Captain)
                .Include(d => d.Lieutenant)
                .FirstOrDefaultAsync(m => m.DivisionNumber == id);
            if (division == null)
            {
                return NotFound();
            }

            return View(division);
        }

        // POST: Divisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var division = await _context.Division.FindAsync(id);
            _context.Division.Remove(division);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DivisionExists(int id)
        {
            return _context.Division.Any(e => e.DivisionNumber == id);
        }
    }
}
