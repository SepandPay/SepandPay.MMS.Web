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
    public class MerchantSyncTablesController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public MerchantSyncTablesController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: MerchantSyncTables
        public async Task<IActionResult> Index()
        {
              return _context.MerchantSyncTables != null ? 
                          View(await _context.MerchantSyncTables.ToListAsync()) :
                          Problem("Entity set 'MMSPortalV3Context.MerchantSyncTables'  is null.");
        }

        // GET: MerchantSyncTables/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.MerchantSyncTables == null)
            {
                return NotFound();
            }

            var merchantSyncTable = await _context.MerchantSyncTables
                .FirstOrDefaultAsync(m => m.id == id);
            if (merchantSyncTable == null)
            {
                return NotFound();
            }

            return View(merchantSyncTable);
        }

        // GET: MerchantSyncTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MerchantSyncTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,merchantid,SyncType,issynced,createdate,syncdate")] MerchantSyncTable merchantSyncTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merchantSyncTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(merchantSyncTable);
        }

        // GET: MerchantSyncTables/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.MerchantSyncTables == null)
            {
                return NotFound();
            }

            var merchantSyncTable = await _context.MerchantSyncTables.FindAsync(id);
            if (merchantSyncTable == null)
            {
                return NotFound();
            }
            return View(merchantSyncTable);
        }

        // POST: MerchantSyncTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,merchantid,SyncType,issynced,createdate,syncdate")] MerchantSyncTable merchantSyncTable)
        {
            if (id != merchantSyncTable.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merchantSyncTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerchantSyncTableExists(merchantSyncTable.id))
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
            return View(merchantSyncTable);
        }

        // GET: MerchantSyncTables/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.MerchantSyncTables == null)
            {
                return NotFound();
            }

            var merchantSyncTable = await _context.MerchantSyncTables
                .FirstOrDefaultAsync(m => m.id == id);
            if (merchantSyncTable == null)
            {
                return NotFound();
            }

            return View(merchantSyncTable);
        }

        // POST: MerchantSyncTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.MerchantSyncTables == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.MerchantSyncTables'  is null.");
            }
            var merchantSyncTable = await _context.MerchantSyncTables.FindAsync(id);
            if (merchantSyncTable != null)
            {
                _context.MerchantSyncTables.Remove(merchantSyncTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MerchantSyncTableExists(long id)
        {
          return (_context.MerchantSyncTables?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
