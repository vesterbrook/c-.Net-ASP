using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotingDojo.Models;

namespace quotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes(string name, string quote)
        {
            var users = DbConnector.Query("SELECT * FROM quotes");
            ViewBag.List = users;
            
            foreach(var user in ViewBag.List)
            {
            ViewBag.Name = name;
            ViewBag.Quote = quote;
            }
            
            return View("Quotes");
        }

        [HttpPost]
        [Route("/quotes")]
        public IActionResult QuotesResults(string name, string quote)
        {
            string n = name;
            string q = quote;
            string insertQ= $"INSERT INTO quotes(name, quotesBox) VALUES('{name}', '{quote}')";
            DbConnector.Execute(insertQ);

            return RedirectToAction("Quotes");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
