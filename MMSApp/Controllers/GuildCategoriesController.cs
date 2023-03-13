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
    public class GuildCategoriesController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public GuildCategoriesController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: GuildCategories
        public async Task<IActionResult> Index()
        {
              return _context.GuildCategories != null ? 
                          View(await _context.GuildCategories.ToListAsync()) :
                          Problem("Entity set 'MMSPortalV3Context.GuildCategories'  is null.");
        }

        // GET: GuildCategories/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.GuildCategories == null)
            {
                return NotFound();
            }

            var guildCategory = await _context.GuildCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guildCategory == null)
            {
                return NotFound();
            }

            return View(guildCategory);
        }

        // GET: GuildCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GuildCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] GuildCategory guildCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guildCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guildCategory);
        }

        // GET: GuildCategories/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.GuildCategories == null)
            {
                return NotFound();
            }

            var guildCategory = await _context.GuildCategories.FindAsync(id);
            if (guildCategory == null)
            {
                return NotFound();
            }
            return View(guildCategory);
        }

        // POST: GuildCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Code,Name,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] GuildCategory guildCategory)
        {
            if (id != guildCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guildCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuildCategoryExists(guildCategory.Id))
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
            return View(guildCategory);
        }

        // GET: GuildCategories/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.GuildCategories == null)
            {
                return NotFound();
            }

            var guildCategory = await _context.GuildCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guildCategory == null)
            {
                return NotFound();
            }

            return View(guildCategory);
        }

        // POST: GuildCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.GuildCategories == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.GuildCategories'  is null.");
            }
            var guildCategory = await _context.GuildCategories.FindAsync(id);
            if (guildCategory != null)
            {
                _context.GuildCategories.Remove(guildCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuildCategoryExists(long id)
        {
          return (_context.GuildCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
