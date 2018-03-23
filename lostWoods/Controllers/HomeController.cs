using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using lostWoods.Models;
using lostWoods.Factory;
namespace lostWoods.Controllers

{
    public class HomeController : Controller
    {
        private readonly TrailFactory trailFactory;
        public HomeController()
        {
            trailFactory = new TrailFactory();
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Trails = trailFactory.FindAll();
            return View();
        }

        [HttpGet]
        [Route("addTrail")]
        public IActionResult AddTrail()
        {
           
            return View();
        }

        [HttpPost]
        [Route("createTrail")]
        public IActionResult createTrail(Trail trail)
        {
            TryValidateModel(trail);
            if(ModelState.IsValid)
            {
                trailFactory.Add(trail);
                return RedirectToAction("Index"); //change RTA to a return view
            }
            else
            {
                return View("addTrail");

            }

        }

        [HttpGet]
        [Route("trails/{id}")]
        public IActionResult viewTrail(int id)
        {
            ViewBag.trail = trailFactory.FindById(id);
            return View("Trail");
        }
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}
