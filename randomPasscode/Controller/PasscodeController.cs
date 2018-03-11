using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace RandomPasscode.Controllers
{
    public class PasscodeController : Controller
    {
        public static int count;
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            Random rand = new Random();
            string passcode = "";
            string options = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            for (int i = 0; i < 14; i++)
            {
                passcode += options[rand.Next(0,options.Length)];
            }
            count++;
            ViewBag.passcode = passcode;
            ViewBag.count = count;
            return View();
        }
    [HttpPost]
    [Route("create")]

    public IActionResult Create(){
        return RedirectToAction("Index");
    }
    }
}