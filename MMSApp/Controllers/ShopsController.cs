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
    public class ShopsController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public ShopsController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: Shops
        public async Task<IActionResult> Index()
        {
            var mMSPortalV3Context = _context.Shops.Include(s => s.City).Include(s => s.GuildCategory);
            return View(await mMSPortalV3Context.ToListAsync());
        }

        // GET: Shops/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Shops == null)
            {
                return NotFound();
            }

            var shop = await _context.Shops
                .Include(s => s.City)
                .Include(s => s.GuildCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shop == null)
            {
                return NotFound();
            }

            return View(shop);
        }

        // GET: Shops/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            ViewData["GuildCategoryId"] = new SelectList(_context.GuildCategories, "Id", "Id");
            return View();
        }

        // POST: Shops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Telephone,AddressFa,AddressEn,WebSiteAddress,IsSharedAccount,IsMultiAccount,ShopPostalCode,ShopFaxNumber,ShopCityPreCode,ShopBusinessLicenseNumber,ShopBusinessLicenseIssueDate,ShopBusinessLicenseExpireDate,ShopEmail,BusinesslicenseImage,RedirectUrl,GuildCategoryId,ShopLogo,CustomerKey,CustomerValue,ShopNameFa,ShopNameEn,CityId,CityCode,taxPayerCode,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", shop.CityId);
            ViewData["GuildCategoryId"] = new SelectList(_context.GuildCategories, "Id", "Id", shop.GuildCategoryId);
            return View(shop);
        }

        // GET: Shops/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Shops == null)
            {
                return NotFound();
            }

            var shop = await _context.Shops.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", shop.CityId);
            ViewData["GuildCategoryId"] = new SelectList(_context.GuildCategories, "Id", "Id", shop.GuildCategoryId);
            return View(shop);
        }

        // POST: Shops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Telephone,AddressFa,AddressEn,WebSiteAddress,IsSharedAccount,IsMultiAccount,ShopPostalCode,ShopFaxNumber,ShopCityPreCode,ShopBusinessLicenseNumber,ShopBusinessLicenseIssueDate,ShopBusinessLicenseExpireDate,ShopEmail,BusinesslicenseImage,RedirectUrl,GuildCategoryId,ShopLogo,CustomerKey,CustomerValue,ShopNameFa,ShopNameEn,CityId,CityCode,taxPayerCode,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] Shop shop)
        {
            if (id != shop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopExists(shop.Id))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", shop.CityId);
            ViewData["GuildCategoryId"] = new SelectList(_context.GuildCategories, "Id", "Id", shop.GuildCategoryId);
            return View(shop);
        }

        // GET: Shops/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Shops == null)
            {
                return NotFound();
            }

            var shop = await _context.Shops
                .Include(s => s.City)
                .Include(s => s.GuildCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shop == null)
            {
                return NotFound();
            }

            return View(shop);
        }

        // POST: Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Shops == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.Shops'  is null.");
            }
            var shop = await _context.Shops.FindAsync(id);
            if (shop != null)
            {
                _context.Shops.Remove(shop);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopExists(long id)
        {
          return (_context.Shops?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
