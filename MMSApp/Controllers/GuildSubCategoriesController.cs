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
    public class GuildSubCategoriesController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public GuildSubCategoriesController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: GuildSubCategories
        public async Task<IActionResult> Index()
        {
            var mMSPortalV3Context = _context.GuildSubCategories.Include(g => g.GuildCategory);
            return View(await mMSPortalV3Context.ToListAsync());
        }

        // GET: GuildSubCategories/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.GuildSubCategories == null)
            {
                return NotFound();
            }

            var guildSubCategory = await _context.GuildSubCategories
                .Include(g => g.GuildCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guildSubCategory == null)
            {
                return NotFound();
            }

            return View(guildSubCategory);
        }

        // GET: GuildSubCategories/Create
        public IActionResult Create()
        {
            ViewData["GuildCategoryId"] = new SelectList(_context.GuildCategories, "Id", "Id");
            return View();
        }

        // POST: GuildSubCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GuildCategoryId,Title,Code,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] GuildSubCategory guildSubCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guildSubCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GuildCategoryId"] = new SelectList(_context.GuildCategories, "Id", "Id", guildSubCategory.GuildCategoryId);
            return View(guildSubCategory);
        }

        // GET: GuildSubCategories/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.GuildSubCategories == null)
            {
                return NotFound();
            }

            var guildSubCategory = await _context.GuildSubCategories.FindAsync(id);
            if (guildSubCategory == null)
            {
                return NotFound();
            }
            ViewData["GuildCategoryId"] = new SelectList(_context.GuildCategories, "Id", "Id", guildSubCategory.GuildCategoryId);
            return View(guildSubCategory);
        }

        // POST: GuildSubCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,GuildCategoryId,Title,Code,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime")] GuildSubCategory guildSubCategory)
        {
            if (id != guildSubCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guildSubCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuildSubCategoryExists(guildSubCategory.Id))
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
            ViewData["GuildCategoryId"] = new SelectList(_context.GuildCategories, "Id", "Id", guildSubCategory.GuildCategoryId);
            return View(guildSubCategory);
        }

        // GET: GuildSubCategories/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.GuildSubCategories == null)
            {
                return NotFound();
            }

            var guildSubCategory = await _context.GuildSubCategories
                .Include(g => g.GuildCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guildSubCategory == null)
            {
                return NotFound();
            }

            return View(guildSubCategory);
        }

        // POST: GuildSubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.GuildSubCategories == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.GuildSubCategories'  is null.");
            }
            var guildSubCategory = await _context.GuildSubCategories.FindAsync(id);
            if (guildSubCategory != null)
            {
                _context.GuildSubCategories.Remove(guildSubCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuildSubCategoryExists(long id)
        {
          return (_context.GuildSubCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
