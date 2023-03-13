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
    public class ContractsController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public ContractsController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: Contracts
        public async Task<IActionResult> Index()
        {
            var mMSPortalV3Context = _context.Contracts.Include(c => c.Customer).Include(c => c.Project).Include(c => c.ShareType);
            return View(await mMSPortalV3Context.ToListAsync());
        }

        // GET: Contracts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Contracts == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts
                .Include(c => c.Customer)
                .Include(c => c.Project)
                .Include(c => c.ShareType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // GET: Contracts/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");
            ViewData["ShareTypeId"] = new SelectList(_context.CommissionTypes, "Id", "SahredType");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContractNumber,ContractDate,CustomerId,ExpireDate,ServiceStartDate,Description,ProjectId,ShareTypeId,ShareAmount,ShareAmountMax,ShareAmountMin,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contract);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id", contract.CustomerId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", contract.ProjectId);
            ViewData["ShareTypeId"] = new SelectList(_context.CommissionTypes, "Id", "SahredType", contract.ShareTypeId);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Contracts == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id", contract.CustomerId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", contract.ProjectId);
            ViewData["ShareTypeId"] = new SelectList(_context.CommissionTypes, "Id", "SahredType", contract.ShareTypeId);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ContractNumber,ContractDate,CustomerId,ExpireDate,ServiceStartDate,Description,ProjectId,ShareTypeId,ShareAmount,ShareAmountMax,ShareAmountMin,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] Contract contract)
        {
            if (id != contract.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contract.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Shops, "Id", "Id", contract.CustomerId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", contract.ProjectId);
            ViewData["ShareTypeId"] = new SelectList(_context.CommissionTypes, "Id", "SahredType", contract.ShareTypeId);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Contracts == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts
                .Include(c => c.Customer)
                .Include(c => c.Project)
                .Include(c => c.ShareType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Contracts == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.Contracts'  is null.");
            }
            var contract = await _context.Contracts.FindAsync(id);
            if (contract != null)
            {
                _context.Contracts.Remove(contract);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractExists(long id)
        {
          return (_context.Contracts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
