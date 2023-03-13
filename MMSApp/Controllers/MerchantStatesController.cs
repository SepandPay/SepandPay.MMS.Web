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
    public class MerchantStatesController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public MerchantStatesController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: MerchantStates
        public async Task<IActionResult> Index()
        {
              return _context.MerchantStates != null ? 
                          View(await _context.MerchantStates.ToListAsync()) :
                          Problem("Entity set 'MMSPortalV3Context.MerchantStates'  is null.");
        }

        // GET: MerchantStates/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.MerchantStates == null)
            {
                return NotFound();
            }

            var merchantState = await _context.MerchantStates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merchantState == null)
            {
                return NotFound();
            }

            return View(merchantState);
        }

        // GET: MerchantStates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MerchantStates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] MerchantState merchantState)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merchantState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(merchantState);
        }

        // GET: MerchantStates/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.MerchantStates == null)
            {
                return NotFound();
            }

            var merchantState = await _context.MerchantStates.FindAsync(id);
            if (merchantState == null)
            {
                return NotFound();
            }
            return View(merchantState);
        }

        // POST: MerchantStates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] MerchantState merchantState)
        {
            if (id != merchantState.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merchantState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerchantStateExists(merchantState.Id))
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
            return View(merchantState);
        }

        // GET: MerchantStates/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.MerchantStates == null)
            {
                return NotFound();
            }

            var merchantState = await _context.MerchantStates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merchantState == null)
            {
                return NotFound();
            }

            return View(merchantState);
        }

        // POST: MerchantStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.MerchantStates == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.MerchantStates'  is null.");
            }
            var merchantState = await _context.MerchantStates.FindAsync(id);
            if (merchantState != null)
            {
                _context.MerchantStates.Remove(merchantState);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MerchantStateExists(long id)
        {
          return (_context.MerchantStates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
