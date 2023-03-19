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
    public class HollowClassificationsController : Controller
    {
        private readonly SRRContext _context;

        public HollowClassificationsController(SRRContext context)
        {
            _context = context;
        }

        // GET: HollowClassifications
        public async Task<IActionResult> Index()
        {
            return View(await _context.HollowClassification.ToListAsync());
        }

        // GET: HollowClassifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hollowClassification = await _context.HollowClassification
                .FirstOrDefaultAsync(m => m.HCId == id);
            if (hollowClassification == null)
            {
                return NotFound();
            }

            return View(hollowClassification);
        }

        // GET: HollowClassifications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HollowClassifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HCId,Name,Description")] HollowClassification hollowClassification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hollowClassification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hollowClassification);
        }

        // GET: HollowClassifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hollowClassification = await _context.HollowClassification.FindAsync(id);
            if (hollowClassification == null)
            {
                return NotFound();
            }
            return View(hollowClassification);
        }

        // POST: HollowClassifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HCId,Name,Description")] HollowClassification hollowClassification)
        {
            if (id != hollowClassification.HCId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hollowClassification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HollowClassificationExists(hollowClassification.HCId))
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
            return View(hollowClassification);
        }

        // GET: HollowClassifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hollowClassification = await _context.HollowClassification
                .FirstOrDefaultAsync(m => m.HCId == id);
            if (hollowClassification == null)
            {
                return NotFound();
            }

            return View(hollowClassification);
        }

        // POST: HollowClassifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hollowClassification = await _context.HollowClassification.FindAsync(id);
            _context.HollowClassification.Remove(hollowClassification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HollowClassificationExists(int id)
        {
            return _context.HollowClassification.Any(e => e.HCId == id);
        }
    }
}
