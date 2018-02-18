using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using trial1.Data;
using trial1.Models;

namespace trial1.Controllers
{
    public class KirimsController : Controller
    {
        private readonly TruckDbContext _context;

        public KirimsController(TruckDbContext context)
        {
            _context = context;
        }

        // GET: Kirims
        public async Task<IActionResult> Index()
        {
            var truckDbContext = _context.Kirims.Include(k => k.Truck);
            return View(await truckDbContext.ToListAsync());
        }

        // GET: Kirims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kirim = await _context.Kirims
                .Include(k => k.Truck)
                .SingleOrDefaultAsync(m => m.KirimID == id);
            if (kirim == null)
            {
                return NotFound();
            }

            return View(kirim);
        }

        // GET: Kirims/Create
        public IActionResult Create()
        {
            ViewData["TruckID"] = new SelectList(_context.Trucks, "ID", "ID");
            return View();
        }

        // POST: Kirims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KirimID,TruckID,KaryawanNIK")] Kirim kirim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kirim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TruckID"] = new SelectList(_context.Trucks, "ID", "ID", kirim.TruckID);
            return View(kirim);
        }

        // GET: Kirims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kirim = await _context.Kirims.SingleOrDefaultAsync(m => m.KirimID == id);
            if (kirim == null)
            {
                return NotFound();
            }
            ViewData["TruckID"] = new SelectList(_context.Trucks, "ID", "ID", kirim.TruckID);
            return View(kirim);
        }

        // POST: Kirims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KirimID,TruckID,KaryawanNIK")] Kirim kirim)
        {
            if (id != kirim.KirimID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kirim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KirimExists(kirim.KirimID))
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
            ViewData["TruckID"] = new SelectList(_context.Trucks, "ID", "ID", kirim.TruckID);
            return View(kirim);
        }

        // GET: Kirims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kirim = await _context.Kirims
                .Include(k => k.Truck)
                .SingleOrDefaultAsync(m => m.KirimID == id);
            if (kirim == null)
            {
                return NotFound();
            }

            return View(kirim);
        }

        // POST: Kirims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kirim = await _context.Kirims.SingleOrDefaultAsync(m => m.KirimID == id);
            _context.Kirims.Remove(kirim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KirimExists(int id)
        {
            return _context.Kirims.Any(e => e.KirimID == id);
        }
    }
}
