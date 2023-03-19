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
    public class HollowsController : Controller
    {
        private readonly SRRContext _context;

        public HollowsController(SRRContext context)
        {
            _context = context;
        }

        // GET: Hollows
        public async Task<IActionResult> Index()
        {
            var sRRContext = _context.Hollow.Include(h => h.HollowClassification).Include(h => h.SoulReaper).Include(h => h.WeaponPower);
            return View(await sRRContext.ToListAsync());
        }

        // GET: Hollows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hollow = await _context.Hollow
                .Include(h => h.HollowClassification)
                .Include(h => h.SoulReaper)
                .Include(h => h.WeaponPower)
                .FirstOrDefaultAsync(m => m.HId == id);
            if (hollow == null)
            {
                return NotFound();
            }

            return View(hollow);
        }

        // GET: Hollows/Create
        public IActionResult Create()
        {
            ViewData["HollowClassificationId"] = new SelectList(_context.HollowClassification, "HCId", "Name");
            ViewData["SRId"] = new SelectList(_context.SoulReaper, "SRId", "FirstName");
            ViewData["WeaponPowerId"] = new SelectList(_context.WeaponPower, "WPId", "FirstForm");
            return View();
        }

        // POST: Hollows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HId,Name,HollowClassificationId,WeaponPowerId,Description,SRId")] Hollow hollow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hollow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HollowClassificationId"] = new SelectList(_context.HollowClassification, "HCId", "Name", hollow.HollowClassificationId);
            ViewData["SRId"] = new SelectList(_context.SoulReaper, "SRId", "FirstName", hollow.SRId);
            ViewData["WeaponPowerId"] = new SelectList(_context.WeaponPower, "WPId", "FirstForm", hollow.WeaponPowerId);
            return View(hollow);
        }

        // GET: Hollows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hollow = await _context.Hollow.FindAsync(id);
            if (hollow == null)
            {
                return NotFound();
            }
            ViewData["HollowClassificationId"] = new SelectList(_context.HollowClassification, "HCId", "Name", hollow.HollowClassificationId);
            ViewData["SRId"] = new SelectList(_context.SoulReaper, "SRId", "FirstName", hollow.SRId);
            ViewData["WeaponPowerId"] = new SelectList(_context.WeaponPower, "WPId", "FirstForm", hollow.WeaponPowerId);
            return View(hollow);
        }

        // POST: Hollows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HId,Name,HollowClassificationId,WeaponPowerId,Description,SRId")] Hollow hollow)
        {
            if (id != hollow.HId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hollow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HollowExists(hollow.HId))
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
            ViewData["HollowClassificationId"] = new SelectList(_context.HollowClassification, "HCId", "Name", hollow.HollowClassificationId);
            ViewData["SRId"] = new SelectList(_context.SoulReaper, "SRId", "FirstName", hollow.SRId);
            ViewData["WeaponPowerId"] = new SelectList(_context.WeaponPower, "WPId", "FirstForm", hollow.WeaponPowerId);
            return View(hollow);
        }

        // GET: Hollows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hollow = await _context.Hollow
                .Include(h => h.HollowClassification)
                .Include(h => h.SoulReaper)
                .Include(h => h.WeaponPower)
                .FirstOrDefaultAsync(m => m.HId == id);
            if (hollow == null)
            {
                return NotFound();
            }

            return View(hollow);
        }

        // POST: Hollows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hollow = await _context.Hollow.FindAsync(id);
            _context.Hollow.Remove(hollow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HollowExists(int id)
        {
            return _context.Hollow.Any(e => e.HId == id);
        }
    }
}
