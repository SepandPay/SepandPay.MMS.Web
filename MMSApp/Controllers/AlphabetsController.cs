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
    public class AlphabetsController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public AlphabetsController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: Alphabets
        public async Task<IActionResult> Index()
        {
              return _context.Alphabets != null ? 
                          View(await _context.Alphabets.ToListAsync()) :
                          Problem("Entity set 'MMSPortalV3Context.Alphabets'  is null.");
        }

        // GET: Alphabets/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Alphabets == null)
            {
                return NotFound();
            }

            var alphabet = await _context.Alphabets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alphabet == null)
            {
                return NotFound();
            }

            return View(alphabet);
        }

        // GET: Alphabets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alphabets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AlphabiticChar,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] Alphabet alphabet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alphabet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alphabet);
        }

        // GET: Alphabets/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Alphabets == null)
            {
                return NotFound();
            }

            var alphabet = await _context.Alphabets.FindAsync(id);
            if (alphabet == null)
            {
                return NotFound();
            }
            return View(alphabet);
        }

        // POST: Alphabets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,AlphabiticChar,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] Alphabet alphabet)
        {
            if (id != alphabet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alphabet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlphabetExists(alphabet.Id))
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
            return View(alphabet);
        }

        // GET: Alphabets/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Alphabets == null)
            {
                return NotFound();
            }

            var alphabet = await _context.Alphabets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alphabet == null)
            {
                return NotFound();
            }

            return View(alphabet);
        }

        // POST: Alphabets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Alphabets == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.Alphabets'  is null.");
            }
            var alphabet = await _context.Alphabets.FindAsync(id);
            if (alphabet != null)
            {
                _context.Alphabets.Remove(alphabet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlphabetExists(long id)
        {
          return (_context.Alphabets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
