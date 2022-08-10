using Microsoft.AspNetCore.Mvc;

namespace ProjectK.Controllers
{
    public class AdminPageController : Controller
    {
        public IActionResult AdminPage()
        {
            return View();
        }
        public IActionResult AllServices()
        {
            return RedirectToAction("Index", "Services");
        }
        public IActionResult AllProducts()
        {
            return RedirectToAction("Index", "Products");
        }
    }
}
