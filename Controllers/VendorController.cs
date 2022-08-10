using Microsoft.AspNetCore.Mvc;


using ProjectK.Models;

namespace ProjectK.Controllers
{
    public class VendorController : Controller
    {
        

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(VendorLogin lg)
        {
            using (ProjectKContext db = new ProjectKContext())
            {
                var vendors = db.VendorM.Where(x => x.VendorId == lg.VendorId && x.Password == lg.Password);
                if (vendors.Count() > 0)
                {
                    var vendor = vendors.FirstOrDefault();
                    HttpContext.Session.SetString("role", vendor.Category);
                    
                    TempData["status"] = "1";

                    return RedirectToAction("vendorpage", "VendorPage");
                }
                else
                {
                    TempData["status"] = "0";
                }
            }
            return View();
        }
        public IActionResult VendorRegistration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult VendorRegistration(Vendor rg)
        {
            using (ProjectKContext db = new ProjectKContext())
            {
                db.VendorM.Add(rg);
                if (db.SaveChanges() > 0)
                {
                    TempData["status"] = "1";
                    ModelState.Clear();
                }
                else
                {
                    TempData["status"] = "0";
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }

    }
}
