using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CheeseMVC.Models;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        static private Dictionary<string, string> Cheeses = new Dictionary<string, string>();

        public IActionResult Index()
        {
            ViewBag.cheeses = Cheeses;
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(string name, string description)
        {
            Cheeses.Add(name, description);
            return Redirect("/Cheese");
        }

        public IActionResult Remove(){
            ViewBag.cheeses = Cheeses;
            return View();
        }
        
        [HttpPost]
        [Route("/Cheese/Remove")]
        public IActionResult RemoveCheese(string[] cheeses)
        {
            Console.WriteLine(cheeses);
            foreach(string cheese in cheeses)
            {
                
                Cheeses.Remove(cheese);
            }
            return Redirect("/Cheese");
        }
    }
}
