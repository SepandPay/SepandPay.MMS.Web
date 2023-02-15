using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMSApp.Models.Entity;

namespace MMSApp.Controllers
{
    public class PspController : Controller
    {
        readonly List<Psp> lst = new();
        public PspController()
        {
            Psp p1 = new() { Id = 1, Name = "psp1", Alias = "alias psp1", IsDeleted = true, IsActive = false, AcceptorCode = "123456", Enabled = true };
            lst.Add(p1);
        }
        // GET: PspController
        public ActionResult Index()
        {
            return View(lst);
        }

        // GET: PspController/Details/5
        public ActionResult Details(int id)
        {
            Psp mypsp = lst.FirstOrDefault(p => p.Id == id);
            return View(mypsp);
        }

        // GET: PspController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PspController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Psp psp)
        {
            try
            {
                lst.Add(psp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PspController/Edit/5
        public ActionResult Edit(int id)
        {
            Psp mypsp = lst.FirstOrDefault(p => p.Id == id);
            return View(mypsp);
        }

        // POST: PspController/Edit/5
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

        // GET: PspController/Delete/5
        public ActionResult Delete(int id)
        {
            Psp mypsp = lst.FirstOrDefault(p => p.Id == id);
            return View(mypsp);
        }

        // POST: PspController/Delete/5
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
