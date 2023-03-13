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
    public class RequestIbansController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public RequestIbansController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: RequestIbans
        public async Task<IActionResult> Index()
        {
            var mMSPortalV3Context = _context.RequestIbans.Include(r => r.Request).Include(r => r.ShareType);
            return View(await mMSPortalV3Context.ToListAsync());
        }

        // GET: RequestIbans/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.RequestIbans == null)
            {
                return NotFound();
            }

            var requestIban = await _context.RequestIbans
                .Include(r => r.Request)
                .Include(r => r.ShareType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestIban == null)
            {
                return NotFound();
            }

            return View(requestIban);
        }

        // GET: RequestIbans/Create
        public IActionResult Create()
        {
            ViewData["RequestId"] = new SelectList(_context.Requests, "Id", "Id");
            ViewData["ShareTypeId"] = new SelectList(_context.CommissionTypes, "Id", "SahredType");
            return View();
        }

        // POST: RequestIbans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Iban,RequestId,AccountNumber,ShareTypeId,SharedAmount,ShareAmountMax,ShareAmountMin,IsMain,OrderNo,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] RequestIban requestIban)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestIban);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RequestId"] = new SelectList(_context.Requests, "Id", "Id", requestIban.RequestId);
            ViewData["ShareTypeId"] = new SelectList(_context.CommissionTypes, "Id", "SahredType", requestIban.ShareTypeId);
            return View(requestIban);
        }

        // GET: RequestIbans/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.RequestIbans == null)
            {
                return NotFound();
            }

            var requestIban = await _context.RequestIbans.FindAsync(id);
            if (requestIban == null)
            {
                return NotFound();
            }
            ViewData["RequestId"] = new SelectList(_context.Requests, "Id", "Id", requestIban.RequestId);
            ViewData["ShareTypeId"] = new SelectList(_context.CommissionTypes, "Id", "SahredType", requestIban.ShareTypeId);
            return View(requestIban);
        }

        // POST: RequestIbans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Iban,RequestId,AccountNumber,ShareTypeId,SharedAmount,ShareAmountMax,ShareAmountMin,IsMain,OrderNo,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] RequestIban requestIban)
        {
            if (id != requestIban.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestIban);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestIbanExists(requestIban.Id))
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
            ViewData["RequestId"] = new SelectList(_context.Requests, "Id", "Id", requestIban.RequestId);
            ViewData["ShareTypeId"] = new SelectList(_context.CommissionTypes, "Id", "SahredType", requestIban.ShareTypeId);
            return View(requestIban);
        }

        // GET: RequestIbans/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.RequestIbans == null)
            {
                return NotFound();
            }

            var requestIban = await _context.RequestIbans
                .Include(r => r.Request)
                .Include(r => r.ShareType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestIban == null)
            {
                return NotFound();
            }

            return View(requestIban);
        }

        // POST: RequestIbans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.RequestIbans == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.RequestIbans'  is null.");
            }
            var requestIban = await _context.RequestIbans.FindAsync(id);
            if (requestIban != null)
            {
                _context.RequestIbans.Remove(requestIban);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestIbanExists(long id)
        {
          return (_context.RequestIbans?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
