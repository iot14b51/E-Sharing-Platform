using Microsoft.AspNetCore.Mvc;
using ProjectK.Models;

namespace ProjectK.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(AdminLogin lg)
        {
            using (ProjectKContext db = new ProjectKContext())
            {
                var Admin = db.AdminM.Where(x => x.AdminId == lg.AdminId && x.Password == lg.Password);
                if (Admin.Count() > 0)
                {
                    var admin = Admin.FirstOrDefault();
                    HttpContext.Session.SetString("role", admin.Category);
                    TempData["status"] = "1";
                    ModelState.Clear();

                    return RedirectToAction("AdminPage", "AdminPage");
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

        public IActionResult CustomerDetails()
        {
            using (ProjectKContext db = new ProjectKContext())
            {
                TempData["CustomerM"] = db.CustomerM.ToList();
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditCustomer(string customerid)
        {
            Customer pp = new Customer();
            using (ProjectKContext db = new ProjectKContext())
            {
                pp = db.CustomerM.Where(x => x.CustomerId == customerid).FirstOrDefault();
            }
            return View(pp);
        }
        [HttpPost]
        public IActionResult EditCustomer(Customer ps)
        {
            using (ProjectKContext db = new ProjectKContext())
            {
                var result = db.CustomerM.Find(ps.CustomerId);
                result.Id = ps.Id;
                result.FirstName = ps.FirstName;
                result.LastName = ps.LastName;
                result.DOB = ps.DOB;
                result.Gender = ps.Gender;
                result.ContactNumber=ps.ContactNumber;
                result.Address = ps.Address;
                result.City = ps.City;
                result.State = ps.State;
                result.zip = ps.zip;
                result.Email = ps.Email;
                result.Category = ps.Category;
                result.CustomerId = ps.CustomerId;
                result.Password = ps.Password;
                result.ConfirmPassword=ps.ConfirmPassword;
               
                db.SaveChanges();
               
            }
            return View();
        }
        public IActionResult DeleteCustomer(string customerid)
        {
            Customer pp = new Customer();
            using (ProjectKContext db = new ProjectKContext())
            {
                pp = db.CustomerM.Where(x => x.CustomerId == customerid).FirstOrDefault();
                db.CustomerM.Remove(pp);
                db.SaveChanges();

            }
            return View();
        }

        public IActionResult ViewCustomerDetails()
        {
            using (ProjectKContext db = new ProjectKContext())
            {
                TempData["CustomerM"] = db.CustomerM.ToList();
            }
            return View();
        }

        public IActionResult VendorDetails()
        {
            using (ProjectKContext db = new ProjectKContext())
            {
                TempData["vendorM"] = db.VendorM.ToList();
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditVendor(string vendorid)
        {
            Vendor pp = new Vendor();
            using (ProjectKContext db = new ProjectKContext())
            {
                pp = db.VendorM.Where(x => x.VendorId == vendorid).FirstOrDefault();
            }
            return View(pp);
        }
        [HttpPost]
        public IActionResult EditVendorr(Vendor ps)
        {
            using (ProjectKContext db = new ProjectKContext())
            {
                var result = db.VendorM.Find(ps.VendorId);
                result.Id = ps.Id;
                result.FirstName = ps.FirstName;
                result.LastName = ps.LastName;
                result.DOB = ps.DOB;
                result.Gender = ps.Gender;
                result.ContactNumber = ps.ContactNumber;
                result.Address = ps.Address;
                result.City = ps.City;
                result.State = ps.State;
                result.zip = ps.zip;
                result.Email = ps.Email;
                result.Category = ps.Category;
                result.VendorId = ps.VendorId;
                result.Password = ps.Password;
                result.ConfirmPassword = ps.ConfirmPassword;

                db.SaveChanges();

            }
            return View();
        }
        public IActionResult DeleteVendor(string vendorid)
        {
            Vendor pp = new Vendor();
            using (ProjectKContext db = new ProjectKContext())
            {
                pp = db.VendorM.Where(x => x.VendorId == vendorid).FirstOrDefault();
                db.VendorM.Remove(pp);
                db.SaveChanges();

            }
            return View();
        }

        public IActionResult ViewVendorDetails()
        {
            using (ProjectKContext db = new ProjectKContext())
            {
                TempData["VendorM"] = db.VendorM.ToList();
            }
            return View();
        }



    }
}
