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
    public class MerchantsController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public MerchantsController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: Merchants
        public async Task<IActionResult> Index()
        {
            var mMSPortalV3Context = _context.Merchants.Include(m => m.Customer).Include(m => m.MerchantState).Include(m => m.Psp).Include(m => m.TerminalType);
            return View(await mMSPortalV3Context.ToListAsync());
        }

        // GET: Merchants/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Merchants == null)
            {
                return NotFound();
            }

            var merchant = await _context.Merchants
                .Include(m => m.Customer)
                .Include(m => m.MerchantState)
                .Include(m => m.Psp)
                .Include(m => m.TerminalType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merchant == null)
            {
                return NotFound();
            }

            return View(merchant);
        }

        // GET: Merchants/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id");
            ViewData["MerchantStateId"] = new SelectList(_context.MerchantStates, "Id", "Title");
            ViewData["PspId"] = new SelectList(_context.PSPs, "Id", "Id");
            ViewData["TerminalTypeId"] = new SelectList(_context.SettelementTypes, "Id", "Description");
            return View();
        }

        // POST: Merchants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PspId,AcceptorCode,TerminalNo,CustomerId,MerchantStateId,TerminalTypeId,merchantKey,Title,PSPUser,PSPPassword,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] Merchant merchant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merchant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id", merchant.CustomerId);
            ViewData["MerchantStateId"] = new SelectList(_context.MerchantStates, "Id", "Title", merchant.MerchantStateId);
            ViewData["PspId"] = new SelectList(_context.PSPs, "Id", "Id", merchant.PspId);
            ViewData["TerminalTypeId"] = new SelectList(_context.SettelementTypes, "Id", "Description", merchant.TerminalTypeId);
            return View(merchant);
        }

        // GET: Merchants/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Merchants == null)
            {
                return NotFound();
            }

            var merchant = await _context.Merchants.FindAsync(id);
            if (merchant == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id", merchant.CustomerId);
            ViewData["MerchantStateId"] = new SelectList(_context.MerchantStates, "Id", "Title", merchant.MerchantStateId);
            ViewData["PspId"] = new SelectList(_context.PSPs, "Id", "Id", merchant.PspId);
            ViewData["TerminalTypeId"] = new SelectList(_context.SettelementTypes, "Id", "Description", merchant.TerminalTypeId);
            return View(merchant);
        }

        // POST: Merchants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PspId,AcceptorCode,TerminalNo,CustomerId,MerchantStateId,TerminalTypeId,merchantKey,Title,PSPUser,PSPPassword,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] Merchant merchant)
        {
            if (id != merchant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merchant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerchantExists(merchant.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id", merchant.CustomerId);
            ViewData["MerchantStateId"] = new SelectList(_context.MerchantStates, "Id", "Title", merchant.MerchantStateId);
            ViewData["PspId"] = new SelectList(_context.PSPs, "Id", "Id", merchant.PspId);
            ViewData["TerminalTypeId"] = new SelectList(_context.SettelementTypes, "Id", "Description", merchant.TerminalTypeId);
            return View(merchant);
        }

        // GET: Merchants/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Merchants == null)
            {
                return NotFound();
            }

            var merchant = await _context.Merchants
                .Include(m => m.Customer)
                .Include(m => m.MerchantState)
                .Include(m => m.Psp)
                .Include(m => m.TerminalType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merchant == null)
            {
                return NotFound();
            }

            return View(merchant);
        }

        // POST: Merchants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Merchants == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.Merchants'  is null.");
            }
            var merchant = await _context.Merchants.FindAsync(id);
            if (merchant != null)
            {
                _context.Merchants.Remove(merchant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MerchantExists(long id)
        {
          return (_context.Merchants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
