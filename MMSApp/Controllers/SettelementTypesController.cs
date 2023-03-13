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
    public class SettelementTypesController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public SettelementTypesController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: SettelementTypes
        public async Task<IActionResult> Index()
        {
              return _context.SettelementTypes != null ? 
                          View(await _context.SettelementTypes.ToListAsync()) :
                          Problem("Entity set 'MMSPortalV3Context.SettelementTypes'  is null.");
        }

        // GET: SettelementTypes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.SettelementTypes == null)
            {
                return NotFound();
            }

            var settelementType = await _context.SettelementTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (settelementType == null)
            {
                return NotFound();
            }

            return View(settelementType);
        }

        // GET: SettelementTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SettelementTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] SettelementType settelementType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(settelementType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(settelementType);
        }

        // GET: SettelementTypes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.SettelementTypes == null)
            {
                return NotFound();
            }

            var settelementType = await _context.SettelementTypes.FindAsync(id);
            if (settelementType == null)
            {
                return NotFound();
            }
            return View(settelementType);
        }

        // POST: SettelementTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Description,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] SettelementType settelementType)
        {
            if (id != settelementType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(settelementType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SettelementTypeExists(settelementType.Id))
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
            return View(settelementType);
        }

        // GET: SettelementTypes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.SettelementTypes == null)
            {
                return NotFound();
            }

            var settelementType = await _context.SettelementTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (settelementType == null)
            {
                return NotFound();
            }

            return View(settelementType);
        }

        // POST: SettelementTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.SettelementTypes == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.SettelementTypes'  is null.");
            }
            var settelementType = await _context.SettelementTypes.FindAsync(id);
            if (settelementType != null)
            {
                _context.SettelementTypes.Remove(settelementType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SettelementTypeExists(long id)
        {
          return (_context.SettelementTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
