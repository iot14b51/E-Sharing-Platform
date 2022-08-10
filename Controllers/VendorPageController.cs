using Microsoft.AspNetCore.Mvc;
using ProjectK.Models;

namespace ProjectK.Controllers
{
    public class VendorPageController : Controller
    {
        public IActionResult vendorpage()
        {
            return View();
        }
        public IActionResult AllServices()
        {
            using (ProjectKContext db = new ProjectKContext())
            {
                TempData["services"] = db.services.ToList();
            }
            return RedirectToAction("Index","Services");
        }
        public IActionResult AllProducts()
        {
            using (ProjectKContext db = new ProjectKContext())
            {
                TempData["productss"] = db.products.ToList();
            }
            return RedirectToAction("Index", "Products");
        }
    }
}
