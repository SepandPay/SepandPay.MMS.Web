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
    public class RequestDetailsController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public RequestDetailsController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: RequestDetails
        public async Task<IActionResult> Index()
        {
            var mMSPortalV3Context = _context.RequestDetails.Include(r => r.Request);
            return View(await mMSPortalV3Context.ToListAsync());
        }

        // GET: RequestDetails/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.RequestDetails == null)
            {
                return NotFound();
            }

            var requestDetail = await _context.RequestDetails
                .Include(r => r.Request)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestDetail == null)
            {
                return NotFound();
            }

            return View(requestDetail);
        }

        // GET: RequestDetails/Create
        public IActionResult Create()
        {
            ViewData["RequestId"] = new SelectList(_context.Requests, "Id", "Id");
            return View();
        }

        // POST: RequestDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RequestId,PrevValue,NewValue,Description,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] RequestDetail requestDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RequestId"] = new SelectList(_context.Requests, "Id", "Id", requestDetail.RequestId);
            return View(requestDetail);
        }

        // GET: RequestDetails/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.RequestDetails == null)
            {
                return NotFound();
            }

            var requestDetail = await _context.RequestDetails.FindAsync(id);
            if (requestDetail == null)
            {
                return NotFound();
            }
            ViewData["RequestId"] = new SelectList(_context.Requests, "Id", "Id", requestDetail.RequestId);
            return View(requestDetail);
        }

        // POST: RequestDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,RequestId,PrevValue,NewValue,Description,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] RequestDetail requestDetail)
        {
            if (id != requestDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestDetailExists(requestDetail.Id))
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
            ViewData["RequestId"] = new SelectList(_context.Requests, "Id", "Id", requestDetail.RequestId);
            return View(requestDetail);
        }

        // GET: RequestDetails/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.RequestDetails == null)
            {
                return NotFound();
            }

            var requestDetail = await _context.RequestDetails
                .Include(r => r.Request)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestDetail == null)
            {
                return NotFound();
            }

            return View(requestDetail);
        }

        // POST: RequestDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.RequestDetails == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.RequestDetails'  is null.");
            }
            var requestDetail = await _context.RequestDetails.FindAsync(id);
            if (requestDetail != null)
            {
                _context.RequestDetails.Remove(requestDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestDetailExists(long id)
        {
          return (_context.RequestDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
