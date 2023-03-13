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
    public class IbansController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public IbansController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: Ibans
        public async Task<IActionResult> Index()
        {
            var mMSPortalV3Context = _context.Ibans.Include(i => i.Customer).Include(i => i.Person).Include(i => i.ShareType);
            return View(await mMSPortalV3Context.ToListAsync());
        }

        // GET: Ibans/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Ibans == null)
            {
                return NotFound();
            }

            var iban = await _context.Ibans
                .Include(i => i.Customer)
                .Include(i => i.Person)
                .Include(i => i.ShareType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iban == null)
            {
                return NotFound();
            }

            return View(iban);
        }

        // GET: Ibans/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id");
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FirstNameFa");
            ViewData["ShareTypeId"] = new SelectList(_context.CommissionTypes, "Id", "SahredType");
            return View();
        }

        // POST: Ibans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Iban1,PersonId,CustomerId,AccountNumber,ShareTypeId,SharedAmount,ShareAmountMax,ShareAmountMin,IsMain,OrderNo,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] Iban iban)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iban);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id", iban.CustomerId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FirstNameFa", iban.PersonId);
            ViewData["ShareTypeId"] = new SelectList(_context.CommissionTypes, "Id", "SahredType", iban.ShareTypeId);
            return View(iban);
        }

        // GET: Ibans/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Ibans == null)
            {
                return NotFound();
            }

            var iban = await _context.Ibans.FindAsync(id);
            if (iban == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id", iban.CustomerId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FirstNameFa", iban.PersonId);
            ViewData["ShareTypeId"] = new SelectList(_context.CommissionTypes, "Id", "SahredType", iban.ShareTypeId);
            return View(iban);
        }

        // POST: Ibans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Iban1,PersonId,CustomerId,AccountNumber,ShareTypeId,SharedAmount,ShareAmountMax,ShareAmountMin,IsMain,OrderNo,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] Iban iban)
        {
            if (id != iban.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iban);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IbanExists(iban.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id", iban.CustomerId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FirstNameFa", iban.PersonId);
            ViewData["ShareTypeId"] = new SelectList(_context.CommissionTypes, "Id", "SahredType", iban.ShareTypeId);
            return View(iban);
        }

        // GET: Ibans/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Ibans == null)
            {
                return NotFound();
            }

            var iban = await _context.Ibans
                .Include(i => i.Customer)
                .Include(i => i.Person)
                .Include(i => i.ShareType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iban == null)
            {
                return NotFound();
            }

            return View(iban);
        }

        // POST: Ibans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Ibans == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.Ibans'  is null.");
            }
            var iban = await _context.Ibans.FindAsync(id);
            if (iban != null)
            {
                _context.Ibans.Remove(iban);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IbanExists(long id)
        {
          return (_context.Ibans?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
