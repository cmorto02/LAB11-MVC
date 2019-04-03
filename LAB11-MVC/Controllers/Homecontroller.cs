using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAB11_MVC.Models;

namespace LAB11_MVC.Controllers
{
    public class Homecontroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(decimal price, int score)
        {
            return RedirectToAction("Results", new { price, score });
        }

        [HttpGet]
        public IActionResult Results(decimal price, decimal score )
        {
            
            return View(Results);
        }
    }
}
