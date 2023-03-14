﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MMSApp.Models;
using MMSApp.Models.ViewModels;

namespace MMSApp.Controllers
{
    public class CustomerCreationController : Controller
    {

        private readonly MMSPortalV3Context _context;

        public CustomerCreationController(MMSPortalV3Context context)
        {
            _context = context;
        }
        // GET: CustomerCreationController
        public ActionResult Index()
        {
            var obj = new CustomerManagerViewModel
            {
                Countries = _context.Countries.ToList()
            };

            var fromDatabaseEF = new SelectList(_context.Countries.ToList(), "Id", "PersianName");
            obj.CountryCombo = fromDatabaseEF;

            return View(obj);
        }

        // GET: CustomerCreationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerCreationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerCreationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerCreationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerCreationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerCreationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerCreationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}