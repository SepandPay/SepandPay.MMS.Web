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
    public class CommissionTypesController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public CommissionTypesController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: CommissionTypes
        public async Task<IActionResult> Index()
        {
              return _context.CommissionTypes != null ? 
                          View(await _context.CommissionTypes.ToListAsync()) :
                          Problem("Entity set 'MMSPortalV3Context.CommissionTypes'  is null.");
        }

        // GET: CommissionTypes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.CommissionTypes == null)
            {
                return NotFound();
            }

            var commissionType = await _context.CommissionTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commissionType == null)
            {
                return NotFound();
            }

            return View(commissionType);
        }

        // GET: CommissionTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CommissionTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SahredType,SharedTypeCode,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] CommissionType commissionType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commissionType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commissionType);
        }

        // GET: CommissionTypes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.CommissionTypes == null)
            {
                return NotFound();
            }

            var commissionType = await _context.CommissionTypes.FindAsync(id);
            if (commissionType == null)
            {
                return NotFound();
            }
            return View(commissionType);
        }

        // POST: CommissionTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,SahredType,SharedTypeCode,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] CommissionType commissionType)
        {
            if (id != commissionType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commissionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommissionTypeExists(commissionType.Id))
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
            return View(commissionType);
        }

        // GET: CommissionTypes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.CommissionTypes == null)
            {
                return NotFound();
            }

            var commissionType = await _context.CommissionTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commissionType == null)
            {
                return NotFound();
            }

            return View(commissionType);
        }

        // POST: CommissionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.CommissionTypes == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.CommissionTypes'  is null.");
            }
            var commissionType = await _context.CommissionTypes.FindAsync(id);
            if (commissionType != null)
            {
                _context.CommissionTypes.Remove(commissionType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommissionTypeExists(long id)
        {
          return (_context.CommissionTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
