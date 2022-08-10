using Microsoft.AspNetCore.Mvc;

namespace ProjectK.Controllers
{
    public class CustomerPageController : Controller
    {
        public IActionResult CustomerPage()
        {
            return View();
        }
    }
}
