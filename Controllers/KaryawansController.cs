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
    public class KaryawansController : Controller
    {
        private readonly TruckDbContext _context;

        public KaryawansController(TruckDbContext context)
        {
            _context = context;
        }

        // GET: Karyawans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Karyawans.ToListAsync());
        }

        // GET: Karyawans/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karyawan = await _context.Karyawans
                .SingleOrDefaultAsync(m => m.ID == id);
            if (karyawan == null)
            {
                return NotFound();
            }

            return View(karyawan);
        }

        // GET: Karyawans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Karyawans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nama,Gender")] Karyawan karyawan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(karyawan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(karyawan);
        }

        // GET: Karyawans/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karyawan = await _context.Karyawans.SingleOrDefaultAsync(m => m.ID == id);
            if (karyawan == null)
            {
                return NotFound();
            }
            return View(karyawan);
        }

        // POST: Karyawans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Nama,Gender")] Karyawan karyawan)
        {
            if (id != karyawan.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(karyawan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KaryawanExists(karyawan.ID))
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
            return View(karyawan);
        }

        // GET: Karyawans/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karyawan = await _context.Karyawans
                .SingleOrDefaultAsync(m => m.ID == id);
            if (karyawan == null)
            {
                return NotFound();
            }

            return View(karyawan);
        }

        // POST: Karyawans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var karyawan = await _context.Karyawans.SingleOrDefaultAsync(m => m.ID == id);
            _context.Karyawans.Remove(karyawan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KaryawanExists(string id)
        {
            return _context.Karyawans.Any(e => e.ID == id);
        }
    }
}
