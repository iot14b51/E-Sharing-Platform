using Microsoft.AspNetCore.Mvc;
using ProjectK.Models;

namespace ProjectK.Controllers
{
    public class BookProductController : Controller
    {
        public IActionResult CustomerIndex()
        {
            {
                using (ProjectKContext db = new ProjectKContext())
                {
                    TempData["products"] = db.products.ToList();
                }
                return View();
            }
        }
        public IActionResult BookProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BookProduct(BookProduct bp)
        {
            if (ModelState.IsValid)
            {
                using (ProjectKContext db = new ProjectKContext())
                {
                    db.bookProducts.Add(bp);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("ProductsView","BookProduct");
        }
        public IActionResult ProductsView()

        {
            using (ProjectKContext db = new ProjectKContext())
            {
                TempData["bookProducts"] = db.bookProducts.ToList();
            }
            return View();
        }
        
        public IActionResult CancelProduct(string productname)
        {
            BookProduct bp = new BookProduct();
            using (ProjectKContext db = new ProjectKContext())
            {
                bp = db.bookProducts.Where(x => x.ProductName == productname).FirstOrDefault();
                db.bookProducts.Remove(bp);
                db.SaveChanges();
            }
             return RedirectToAction("ProductsView","BookProduct");
        }

    }
}
