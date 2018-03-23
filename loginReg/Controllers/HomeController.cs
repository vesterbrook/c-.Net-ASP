using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using loginReg.Models;

namespace loginReg.Controllers
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
        [Route("login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Logged()
        {
            return View("Register");
        }
     
        
        [HttpPost] // A post request
        [Route("Register")] //The route register

        public IActionResult Register(RegUser newUser) 
        {

	        if(ModelState.IsValid)
	    {
	    string query = $"INSERT INTO loginReg (FirstName, LastName, Password, Email) VALUES ('{newUser.FirstName}', '{newUser.LastName}', '{newUser.Password}','{newUser.Email}')";

	    DbConnector.Execute(query);

        return View("Register");
	    }
	        else
	    {

		return View("Index");
	}


}


//         [HttpPost]
//         [Route("login")]
//         public IActionResult Login(LoginUser model)
//         {
//             if (ModelState.IsValid)
//             {
//                 //handle success
//             }
//             handle errors

//         }

//         if(TryValidateModel(NewUser) == false){

//         ViewBag.errors = ModelState.Values;
//         return View("Error");
//         }
//         else{

//         return View("formPage");
//         }
//  }
//         public IActionResult Error()
//         {
//             return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//         }
//     }
}
}