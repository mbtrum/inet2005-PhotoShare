using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
//using PhotoShare.Models;

namespace PhotoShare.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            // Constructor code goes here        
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}