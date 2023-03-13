using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MMSApp.Models;

namespace MMSApp.Controllers
{
    public class DegreesController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public DegreesController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: Degrees
        public async Task<IActionResult> Index()
        {
            return _context.Degrees != null ?
                        View(await _context.Degrees.ToListAsync()) :
                        Problem("Entity set 'MMSPortalV3Context.Degrees'  is null.");
            // return View();
        }

        // GET: Degrees/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Degrees == null)
            {
                return NotFound();
            }

            var degree = await _context.Degrees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (degree == null)
            {
                return NotFound();
            }

            return View(degree);
        }

        // GET: Degrees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Degrees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] Degree degree)
        {
            if (ModelState.IsValid)
            {
                _context.Add(degree);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(degree);
        }

        // GET: Degrees/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Degrees == null)
            {
                return NotFound();
            }

            var degree = await _context.Degrees.FindAsync(id);
            if (degree == null)
            {
                return NotFound();
            }
            return View(degree);
        }

        // POST: Degrees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] Degree degree)
        {
            if (id != degree.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(degree);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DegreeExists(degree.Id))
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
            return View(degree);
        }

        // GET: Degrees/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Degrees == null)
            {
                return NotFound();
            }

            var degree = await _context.Degrees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (degree == null)
            {
                return NotFound();
            }

            return View(degree);
        }

        // POST: Degrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Degrees == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.Degrees'  is null.");
            }
            var degree = await _context.Degrees.FindAsync(id);
            if (degree != null)
            {
                _context.Degrees.Remove(degree);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DegreeExists(long id)
        {
            return (_context.Degrees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
