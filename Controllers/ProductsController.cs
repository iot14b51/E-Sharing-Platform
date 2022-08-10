using Microsoft.AspNetCore.Mvc;
using ProjectK.Models;

namespace ProjectK.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            using (ProjectKContext db = new ProjectKContext())
            {
                TempData["products"] = db.products.ToList();
            }
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Products p)
        {
            if (ModelState.IsValid)
            {
                using (ProjectKContext db = new ProjectKContext())
                {
                    db.products.Add(p);
                    int count = db.SaveChanges();
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
            return View();
        }
        public IActionResult Edit(int id)
        {
            Products pp = new Products();
            using (ProjectKContext db = new ProjectKContext())
            {
                pp = db.products.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(pp);
        }
        [HttpPost]
        public IActionResult Edit(Products ps)
        {
            using (ProjectKContext db = new ProjectKContext())
            {
                var result = db.products.Find(ps.Id);
                result.ProductName = ps.ProductName;
                result.Quantity = ps.Quantity;
                result.Price = ps.Price;
                db.SaveChanges();
                ModelState.Clear();

            }
            return RedirectToAction("Index", "Products");
        }
        public IActionResult Delete(int id)
        {
            Products pp = new Products();
            using (ProjectKContext db = new ProjectKContext())
            {
                pp = db.products.Where(x => x.Id == id).FirstOrDefault();
                db.products.Remove(pp);
                db.SaveChanges();  
            }
            return RedirectToAction("Index","Products");
        }
        public IActionResult Details()
        {
            using (ProjectKContext db = new ProjectKContext())
            {
                TempData["products"] = db.products.ToList();
            }
            return View();
        }
    }
}
