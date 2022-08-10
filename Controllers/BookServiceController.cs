using Microsoft.AspNetCore.Mvc;
using ProjectK.Models;

namespace ProjectK.Controllers
{
    public class BookServiceController : Controller
    {
        public IActionResult CustomerIndex()
        {
            {
                using (ProjectKContext db = new ProjectKContext())
                {
                    TempData["services"] = db.services.ToList();
                }
                return View();
            }
        }
        public IActionResult BookService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BookService(BookService bs)
        {
            if (ModelState.IsValid)
            {
                using (ProjectKContext db = new ProjectKContext())
                {
                    db.bookServices.Add(bs);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("ServicesView", "BookService");
        }
        public IActionResult ServicesView()

        {
            using (ProjectKContext db = new ProjectKContext())
            {
                TempData["bookServices"] = db.bookServices.ToList();
            }
            return View();
        }

        public IActionResult CancelService(string Servicename)
        {
            BookService bs = new BookService();
            using (ProjectKContext db = new ProjectKContext())
            {
                bs = db.bookServices.Where(x => x.ServiceName == Servicename).FirstOrDefault();
                db.bookServices.Remove(bs);
                db.SaveChanges();
            }
            return RedirectToAction("ServicesView", "BookService");
        }
        public IActionResult Order()
        {
            return View();
        }

    }
}

    

