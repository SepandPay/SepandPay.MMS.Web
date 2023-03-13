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
    public class PeopleController : Controller
    {
        private readonly MMSPortalV3Context _context;

        public PeopleController(MMSPortalV3Context context)
        {
            _context = context;
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            var mMSPortalV3Context = _context.Persons.Include(p => p.BirthCertificateAlphabiticNo).Include(p => p.Country).Include(p => p.Degree).Include(p => p.NationalityCountry);
            return View(await mMSPortalV3Context.ToListAsync());
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .Include(p => p.BirthCertificateAlphabiticNo)
                .Include(p => p.Country)
                .Include(p => p.Degree)
                .Include(p => p.NationalityCountry)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            ViewData["BirthCertificateAlphabiticNoId"] = new SelectList(_context.Alphabets, "Id", "AlphabiticChar");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id");
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "Id", "Id");
            ViewData["NationalityCountryId"] = new SelectList(_context.Countries, "Id", "Id");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IsDisable,NationalNumber,FirstNameFa,LastNameFa,FirstNameEn,LastNameEn,NationalityCountryId,BirthLocation,BirthDate,BirthCertificatePlaceOfIssue,FatherNameFa,FatherNameEn,Gender,BirthCertificateNo,BirthCertificateSerial,BirthCertificateAlphabiticNoId,BirthCertificateNumericNo,DegreeId,PostalCode,IsLegal,IsForeign,RegisterDate,RegisterNo,ComNameEn,ComNameFa,RsidencyType,VitalStatus,NationalLegalCode,CountryId,CountryAbbrivation,ForeignPervasiveCode,PassportNo,PassportExpireDate,CommercialCode,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime,PersonTypeId")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BirthCertificateAlphabiticNoId"] = new SelectList(_context.Alphabets, "Id", "AlphabiticChar", person.BirthCertificateAlphabiticNoId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", person.CountryId);
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "Id", "Id", person.DegreeId);
            ViewData["NationalityCountryId"] = new SelectList(_context.Countries, "Id", "Id", person.NationalityCountryId);
            return View(person);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            ViewData["BirthCertificateAlphabiticNoId"] = new SelectList(_context.Alphabets, "Id", "AlphabiticChar", person.BirthCertificateAlphabiticNoId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", person.CountryId);
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "Id", "Id", person.DegreeId);
            ViewData["NationalityCountryId"] = new SelectList(_context.Countries, "Id", "Id", person.NationalityCountryId);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,IsDisable,NationalNumber,FirstNameFa,LastNameFa,FirstNameEn,LastNameEn,NationalityCountryId,BirthLocation,BirthDate,BirthCertificatePlaceOfIssue,FatherNameFa,FatherNameEn,Gender,BirthCertificateNo,BirthCertificateSerial,BirthCertificateAlphabiticNoId,BirthCertificateNumericNo,DegreeId,PostalCode,IsLegal,IsForeign,RegisterDate,RegisterNo,ComNameEn,ComNameFa,RsidencyType,VitalStatus,NationalLegalCode,CountryId,CountryAbbrivation,ForeignPervasiveCode,PassportNo,PassportExpireDate,CommercialCode,IsDeleted,IsActive,CreatorUserId,CreateDate,UpdaterUserId,UpdateTime,PersonTypeId")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
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
            ViewData["BirthCertificateAlphabiticNoId"] = new SelectList(_context.Alphabets, "Id", "AlphabiticChar", person.BirthCertificateAlphabiticNoId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", person.CountryId);
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "Id", "Id", person.DegreeId);
            ViewData["NationalityCountryId"] = new SelectList(_context.Countries, "Id", "Id", person.NationalityCountryId);
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .Include(p => p.BirthCertificateAlphabiticNo)
                .Include(p => p.Country)
                .Include(p => p.Degree)
                .Include(p => p.NationalityCountry)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Persons == null)
            {
                return Problem("Entity set 'MMSPortalV3Context.Persons'  is null.");
            }
            var person = await _context.Persons.FindAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(long id)
        {
          return (_context.Persons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
