using Microsoft.AspNetCore.Mvc;
using ProjectK.Models;

namespace ProjectK.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(CustomerLogin lg)
        {
           
            using (ProjectKContext db = new ProjectKContext())
            {
                var customers = db.CustomerM.Where(x => x.CustomerId == lg.CustomerId && x.Password == lg.Password);
                if (customers.Count() > 0)
                {
                    var customer = customers.FirstOrDefault();
                    HttpContext.Session.SetString("role", customer.Category);
                    TempData["status"] = "1";

                    return RedirectToAction("CustomerPage", "CustomerPage");
                }
                else
                {
                    TempData["status"] = "0";
                }
            }
            return View();
        }
        public IActionResult CustomerRegistration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CustomerRegistration(Customer rg)
        {
            using (ProjectKContext db = new ProjectKContext())
            {
                db.CustomerM.Add(rg);
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
