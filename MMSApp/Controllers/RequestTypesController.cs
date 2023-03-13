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
    public class RequestTypesController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public RequestTypesController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: RequestTypes
        public async Task<IActionResult> Index()
        {
              return _context.RequestTypes != null ? 
                          View(await _context.RequestTypes.ToListAsync()) :
                          Problem("Entity set 'MMSPortalV3Context.RequestTypes'  is null.");
        }

        // GET: RequestTypes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.RequestTypes == null)
            {
                return NotFound();
            }

            var requestType = await _context.RequestTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestType == null)
            {
                return NotFound();
            }

            return View(requestType);
        }

        // GET: RequestTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RequestTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Request,PspRequestTitle,PspRequestCode,ShaparakSatetTitle,ShaparakSatetCode,Description,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] RequestType requestType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requestType);
        }

        // GET: RequestTypes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.RequestTypes == null)
            {
                return NotFound();
            }

            var requestType = await _context.RequestTypes.FindAsync(id);
            if (requestType == null)
            {
                return NotFound();
            }
            return View(requestType);
        }

        // POST: RequestTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Request,PspRequestTitle,PspRequestCode,ShaparakSatetTitle,ShaparakSatetCode,Description,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] RequestType requestType)
        {
            if (id != requestType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestTypeExists(requestType.Id))
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
            return View(requestType);
        }

        // GET: RequestTypes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.RequestTypes == null)
            {
                return NotFound();
            }

            var requestType = await _context.RequestTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestType == null)
            {
                return NotFound();
            }

            return View(requestType);
        }

        // POST: RequestTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.RequestTypes == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.RequestTypes'  is null.");
            }
            var requestType = await _context.RequestTypes.FindAsync(id);
            if (requestType != null)
            {
                _context.RequestTypes.Remove(requestType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestTypeExists(long id)
        {
          return (_context.RequestTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
