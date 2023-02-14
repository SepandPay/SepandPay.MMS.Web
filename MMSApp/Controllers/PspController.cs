using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMSApp.Models.Entity;

namespace MMSApp.Controllers
{
    public class PspController : Controller
    {
        List<Psp> lst = new();
        public PspController()
        {
            Psp p1 = new Psp { Id = 1, Name = "psp1", Alias = "psp1" };
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
            Psp mypsp = lst.Where(p => p.Id == id).FirstOrDefault();
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
            return View();
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
            return View();
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
