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
    public class MarketerContractsController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public MarketerContractsController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: MarketerContracts
        public async Task<IActionResult> Index()
        {
            var mMSPortalV3Context = _context.MarketerContracts.Include(m => m.Customer).Include(m => m.MarketerPerson).Include(m => m.ShareType);
            return View(await mMSPortalV3Context.ToListAsync());
        }

        // GET: MarketerContracts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.MarketerContracts == null)
            {
                return NotFound();
            }

            var marketerContract = await _context.MarketerContracts
                .Include(m => m.Customer)
                .Include(m => m.MarketerPerson)
                .Include(m => m.ShareType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marketerContract == null)
            {
                return NotFound();
            }

            return View(marketerContract);
        }

        // GET: MarketerContracts/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id");
            ViewData["MarketerPersonId"] = new SelectList(_context.Persons, "Id", "FirstNameFa");
            ViewData["ShareTypeId"] = new SelectList(_context.CommissionTypes, "Id", "SahredType");
            return View();
        }

        // POST: MarketerContracts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContractDate,Description,ShareTypeId,SharedAmount,ShareAmountMax,ShareAmountMin,Iban,CustomerId,MarketerPersonId,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] MarketerContract marketerContract)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marketerContract);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id", marketerContract.CustomerId);
            ViewData["MarketerPersonId"] = new SelectList(_context.Persons, "Id", "FirstNameFa", marketerContract.MarketerPersonId);
            ViewData["ShareTypeId"] = new SelectList(_context.CommissionTypes, "Id", "SahredType", marketerContract.ShareTypeId);
            return View(marketerContract);
        }

        // GET: MarketerContracts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.MarketerContracts == null)
            {
                return NotFound();
            }

            var marketerContract = await _context.MarketerContracts.FindAsync(id);
            if (marketerContract == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id", marketerContract.CustomerId);
            ViewData["MarketerPersonId"] = new SelectList(_context.Persons, "Id", "FirstNameFa", marketerContract.MarketerPersonId);
            ViewData["ShareTypeId"] = new SelectList(_context.CommissionTypes, "Id", "SahredType", marketerContract.ShareTypeId);
            return View(marketerContract);
        }

        // POST: MarketerContracts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ContractDate,Description,ShareTypeId,SharedAmount,ShareAmountMax,ShareAmountMin,Iban,CustomerId,MarketerPersonId,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] MarketerContract marketerContract)
        {
            if (id != marketerContract.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marketerContract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarketerContractExists(marketerContract.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id", marketerContract.CustomerId);
            ViewData["MarketerPersonId"] = new SelectList(_context.Persons, "Id", "FirstNameFa", marketerContract.MarketerPersonId);
            ViewData["ShareTypeId"] = new SelectList(_context.CommissionTypes, "Id", "SahredType", marketerContract.ShareTypeId);
            return View(marketerContract);
        }

        // GET: MarketerContracts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.MarketerContracts == null)
            {
                return NotFound();
            }

            var marketerContract = await _context.MarketerContracts
                .Include(m => m.Customer)
                .Include(m => m.MarketerPerson)
                .Include(m => m.ShareType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marketerContract == null)
            {
                return NotFound();
            }

            return View(marketerContract);
        }

        // POST: MarketerContracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.MarketerContracts == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.MarketerContracts'  is null.");
            }
            var marketerContract = await _context.MarketerContracts.FindAsync(id);
            if (marketerContract != null)
            {
                _context.MarketerContracts.Remove(marketerContract);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarketerContractExists(long id)
        {
          return (_context.MarketerContracts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
