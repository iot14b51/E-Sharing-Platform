using Microsoft.AspNetCore.Mvc;
using ProjectK.Models;

namespace ProjectK.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            using (ProjectKContext db = new ProjectKContext())
            {
                TempData["services"] = db.services.ToList();
            }
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Services s)
        {
            if (ModelState.IsValid)
            {
                using (ProjectKContext db = new ProjectKContext())
                {
                    db.services.Add(s);
                    int count=db.SaveChanges();
                    if (count > 0)
                    {
                        TempData["status"] = "1";
                        db.SaveChanges();
                    }
                    else
                    {
                        TempData["status"] = "0";
                    }

                }
            }
            return RedirectToAction("Index","Services");
        }
        public IActionResult Edit(int id)
        {
            Services pp = new Services();
            using (ProjectKContext db = new ProjectKContext())
            {
                pp = db.services.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(pp);
        }
        [HttpPost]
        public IActionResult Edit(Services sp)
        {
            using (ProjectKContext db = new ProjectKContext())
            {
                var result = db.services.Find(sp.Id);
                result.ServiceName = sp.ServiceName;
                result.Price = sp.Price;
                db.SaveChanges();
                ModelState.Clear();

            }
            return RedirectToAction("Index", "Services");
        }
        public IActionResult Delete(int id)
        {
            Services sp = new Services();
            using (ProjectKContext db = new ProjectKContext())
            {
                sp = db.services.Where(x => x.Id == id).FirstOrDefault();
                db.services.Remove(sp);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Services");
        }

        public IActionResult Details()
        {
            using (ProjectKContext db = new ProjectKContext())
            {
                TempData["services"] = db.services.ToList();
            }
            return View();
        }
    }
}
