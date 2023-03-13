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
    public class ShopPersonsController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public ShopPersonsController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: ShopPersons
        public async Task<IActionResult> Index()
        {
            var mMSPortalV3Context = _context.ShopPersons.Include(s => s.Person).Include(s => s.Shop);
            return View(await mMSPortalV3Context.ToListAsync());
        }

        // GET: ShopPersons/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.ShopPersons == null)
            {
                return NotFound();
            }

            var shopPerson = await _context.ShopPersons
                .Include(s => s.Person)
                .Include(s => s.Shop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopPerson == null)
            {
                return NotFound();
            }

            return View(shopPerson);
        }

        // GET: ShopPersons/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FirstNameFa");
            ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "Id");
            return View();
        }

        // POST: ShopPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShopId,PersonId,IsMainPerson,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] ShopPerson shopPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FirstNameFa", shopPerson.PersonId);
            ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "Id", shopPerson.ShopId);
            return View(shopPerson);
        }

        // GET: ShopPersons/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.ShopPersons == null)
            {
                return NotFound();
            }

            var shopPerson = await _context.ShopPersons.FindAsync(id);
            if (shopPerson == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FirstNameFa", shopPerson.PersonId);
            ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "Id", shopPerson.ShopId);
            return View(shopPerson);
        }

        // POST: ShopPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ShopId,PersonId,IsMainPerson,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] ShopPerson shopPerson)
        {
            if (id != shopPerson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopPersonExists(shopPerson.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FirstNameFa", shopPerson.PersonId);
            ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "Id", shopPerson.ShopId);
            return View(shopPerson);
        }

        // GET: ShopPersons/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.ShopPersons == null)
            {
                return NotFound();
            }

            var shopPerson = await _context.ShopPersons
                .Include(s => s.Person)
                .Include(s => s.Shop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopPerson == null)
            {
                return NotFound();
            }

            return View(shopPerson);
        }

        // POST: ShopPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.ShopPersons == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.ShopPersons'  is null.");
            }
            var shopPerson = await _context.ShopPersons.FindAsync(id);
            if (shopPerson != null)
            {
                _context.ShopPersons.Remove(shopPerson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopPersonExists(long id)
        {
          return (_context.ShopPersons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
