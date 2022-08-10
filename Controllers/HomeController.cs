using Microsoft.AspNetCore.Mvc;
using ProjectK.Models;
using System.Diagnostics;

namespace ProjectK.Controllers
{
    public class HomeController : Controller
    {
       public IActionResult Home()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}