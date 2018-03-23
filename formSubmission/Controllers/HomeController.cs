using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using formSubmission.Models;

namespace formSubmission.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("index");
        }

     
        
        [HttpPost]
        [Route("success")]
        public IActionResult Register(string firstName, string lastName, string age, string Email, string Password)
        {
            User NewUser = new User
            {
            firstName = firstName,
            lastName = lastName,
            Age = age,
            Email = Email,
            Password = Password
        };
        if(TryValidateModel(NewUser) == false){

        ViewBag.errors = ModelState.Values;
        return View("Error");
        }
        else{

        return View("formPage");
        }
 }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
