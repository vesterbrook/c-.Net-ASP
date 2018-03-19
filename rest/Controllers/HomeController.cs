using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rest.Models;

namespace rest.Controllers
{
    public class HomeController : Controller
    {
        
    private RestContext _context;
 
    public HomeController(RestContext context)
        {
        _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = ModelState.Values;
            return View("Index");
        }

        [HttpPost]
        [Route("createReview")]
        public IActionResult createReview(Rest newRest)
        {   
            
            if(ModelState.IsValid)
            {

            _context.Add(newRest);
            _context.SaveChanges();

            return RedirectToAction("Review");
        }
            return View("Index");
            }   

        [HttpGet]
        [Route("reviews")]
        public IActionResult Review()
        {
            List<Rest> rName = _context.rest.ToList();
            
            ViewBag.Reviews = rName.OrderByDescending(r => r.visitDate);
            return View("Reviews");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
