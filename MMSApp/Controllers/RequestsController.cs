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
    public class RequestsController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public RequestsController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: Requests
        public async Task<IActionResult> Index()
        {
            var mMSPortalV3Context = _context.Requests.Include(r => r.Customer).Include(r => r.Merchant).Include(r => r.Psp).Include(r => r.RequestState).Include(r => r.RequestType);
            return View(await mMSPortalV3Context.ToListAsync());
        }

        // GET: Requests/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Requests == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Customer)
                .Include(r => r.Merchant)
                .Include(r => r.Psp)
                .Include(r => r.RequestState)
                .Include(r => r.RequestType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Requests/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id");
            ViewData["MerchantId"] = new SelectList(_context.Merchants, "Id", "Id");
            ViewData["PspId"] = new SelectList(_context.PSPs, "Id", "Id");
            ViewData["RequestStateId"] = new SelectList(_context.RequestStates, "Id", "Id");
            ViewData["RequestTypeId"] = new SelectList(_context.RequestTypes, "Id", "Id");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,InstallationDate,Description,ShaparakDescription,RequestTypeId,PspId,RequestStateId,ShaparakTrackingNumber,TrackingNumber,ShaparakState,LastCallTime,InsertDateTime,RequestData,EditedBy,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime,MerchantId")] Request request)
        {
            if (ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id", request.CustomerId);
            ViewData["MerchantId"] = new SelectList(_context.Merchants, "Id", "Id", request.MerchantId);
            ViewData["PspId"] = new SelectList(_context.PSPs, "Id", "Id", request.PspId);
            ViewData["RequestStateId"] = new SelectList(_context.RequestStates, "Id", "Id", request.RequestStateId);
            ViewData["RequestTypeId"] = new SelectList(_context.RequestTypes, "Id", "Id", request.RequestTypeId);
            return View(request);
        }

        // GET: Requests/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Requests == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id", request.CustomerId);
            ViewData["MerchantId"] = new SelectList(_context.Merchants, "Id", "Id", request.MerchantId);
            ViewData["PspId"] = new SelectList(_context.PSPs, "Id", "Id", request.PspId);
            ViewData["RequestStateId"] = new SelectList(_context.RequestStates, "Id", "Id", request.RequestStateId);
            ViewData["RequestTypeId"] = new SelectList(_context.RequestTypes, "Id", "Id", request.RequestTypeId);
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CustomerId,InstallationDate,Description,ShaparakDescription,RequestTypeId,PspId,RequestStateId,ShaparakTrackingNumber,TrackingNumber,ShaparakState,LastCallTime,InsertDateTime,RequestData,EditedBy,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime,MerchantId")] Request request)
        {
            if (id != request.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id", request.CustomerId);
            ViewData["MerchantId"] = new SelectList(_context.Merchants, "Id", "Id", request.MerchantId);
            ViewData["PspId"] = new SelectList(_context.PSPs, "Id", "Id", request.PspId);
            ViewData["RequestStateId"] = new SelectList(_context.RequestStates, "Id", "Id", request.RequestStateId);
            ViewData["RequestTypeId"] = new SelectList(_context.RequestTypes, "Id", "Id", request.RequestTypeId);
            return View(request);
        }

        // GET: Requests/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Requests == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Customer)
                .Include(r => r.Merchant)
                .Include(r => r.Psp)
                .Include(r => r.RequestState)
                .Include(r => r.RequestType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Requests == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.Requests'  is null.");
            }
            var request = await _context.Requests.FindAsync(id);
            if (request != null)
            {
                _context.Requests.Remove(request);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(long id)
        {
          return (_context.Requests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
