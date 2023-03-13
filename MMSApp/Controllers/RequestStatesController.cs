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
    public class RequestStatesController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public RequestStatesController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: RequestStates
        public async Task<IActionResult> Index()
        {
              return _context.RequestStates != null ? 
                          View(await _context.RequestStates.ToListAsync()) :
                          Problem("Entity set 'MMSPortalV3Context.RequestStates'  is null.");
        }

        // GET: RequestStates/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.RequestStates == null)
            {
                return NotFound();
            }

            var requestState = await _context.RequestStates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestState == null)
            {
                return NotFound();
            }

            return View(requestState);
        }

        // GET: RequestStates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RequestStates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] RequestState requestState)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requestState);
        }

        // GET: RequestStates/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.RequestStates == null)
            {
                return NotFound();
            }

            var requestState = await _context.RequestStates.FindAsync(id);
            if (requestState == null)
            {
                return NotFound();
            }
            return View(requestState);
        }

        // POST: RequestStates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] RequestState requestState)
        {
            if (id != requestState.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestStateExists(requestState.Id))
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
            return View(requestState);
        }

        // GET: RequestStates/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.RequestStates == null)
            {
                return NotFound();
            }

            var requestState = await _context.RequestStates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestState == null)
            {
                return NotFound();
            }

            return View(requestState);
        }

        // POST: RequestStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.RequestStates == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.RequestStates'  is null.");
            }
            var requestState = await _context.RequestStates.FindAsync(id);
            if (requestState != null)
            {
                _context.RequestStates.Remove(requestState);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestStateExists(long id)
        {
          return (_context.RequestStates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
