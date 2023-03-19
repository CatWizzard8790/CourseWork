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
    public class WeaponPowersController : Controller
    {
        private readonly SRRContext _context;

        public WeaponPowersController(SRRContext context)
        {
            _context = context;
        }

        // GET: WeaponPowers
        public async Task<IActionResult> Index()
        {
            return View(await _context.WeaponPower.ToListAsync());
        }

        // GET: WeaponPowers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weaponPower = await _context.WeaponPower
                .FirstOrDefaultAsync(m => m.WPId == id);
            if (weaponPower == null)
            {
                return NotFound();
            }

            return View(weaponPower);
        }

        // GET: WeaponPowers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeaponPowers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WPId,FirstForm,SecondForm,PType,Description")] WeaponPower weaponPower)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weaponPower);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weaponPower);
        }

        // GET: WeaponPowers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weaponPower = await _context.WeaponPower.FindAsync(id);
            if (weaponPower == null)
            {
                return NotFound();
            }
            return View(weaponPower);
        }

        // POST: WeaponPowers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WPId,FirstForm,SecondForm,PType,Description")] WeaponPower weaponPower)
        {
            if (id != weaponPower.WPId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weaponPower);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeaponPowerExists(weaponPower.WPId))
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
            return View(weaponPower);
        }

        // GET: WeaponPowers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weaponPower = await _context.WeaponPower
                .FirstOrDefaultAsync(m => m.WPId == id);
            if (weaponPower == null)
            {
                return NotFound();
            }

            return View(weaponPower);
        }

        // POST: WeaponPowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weaponPower = await _context.WeaponPower.FindAsync(id);
            _context.WeaponPower.Remove(weaponPower);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeaponPowerExists(int id)
        {
            return _context.WeaponPower.Any(e => e.WPId == id);
        }
    }
}
