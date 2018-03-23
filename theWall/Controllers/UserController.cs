using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using theWall;
using theWall.Models;




namespace theWall.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("id") == null)
            {
                return View();
            }
            else 
            {
                return RedirectToAction("Wall", "Wall");
            }
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

     
        
        [HttpPost] // A post request
        [Route("Register")] //The route register

        public IActionResult Register(RegUser newUser) 
        {

	        if(ModelState.IsValid)
	        {
                string checkEmail = $"SELECT * FROM users WHERE(email = '{newUser.Email}')";
                var exists = DbConnector.Query(checkEmail);

                if(exists.Count > 0)
                {
                    ViewBag.Email = "This email is already in use!";
                
                    return View("Index");
                }


	            else
	            {
	            string query = $"INSERT INTO users (firstName, lastName, password, email) VALUES ('{newUser.FirstName}', '{newUser.LastName}', '{newUser.Password}','{newUser.Email}')";
                System.Console.WriteLine(query);
	            DbConnector.Execute(query);
                HttpContext.Session.SetString("user", newUser.Email);
                
                string check = $"SELECT * FROM users WHERE(email = '{newUser.Email}')";
                var user = DbConnector.Query(check);
                int id = (int)user[0]["id"];
                
                HttpContext.Session.SetInt32("id", id);

		        return RedirectToAction("Wall", "Wall");
                }
            }
            
            return View("Index");
	}





        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginUser model)
        {
            if (ModelState.IsValid)
            {
                string query = $"SELECT * FROM users WHERE(email = '{model.Email}')";  
                var exists = DbConnector.Query(query);
                if(exists.Count == 0)
                {
                    ViewBag.Email = "Email does not exist!";
                    return View("Index");
                }
                else
                {
                    string pass = (exists[0]["password"]).ToString();
                    if(pass !=  model.Password)
                    {
                        ViewBag.password = "Wrong Password!";
                        return View("Index");
                    }
                    else
                    {
                    int id = (int)exists[0]["id"];
                    System.Console.WriteLine(id);
                    HttpContext.Session.SetInt32("id", id);
                    string firstName = (exists[0]["firstName"]).ToString();
                    string lastName = (exists[0]["lastName"]).ToString();
                    string name = firstName + " " + lastName;
                    HttpContext.Session.SetString("name", name);
                    TempData["name"] = HttpContext.Session.GetString("name");
                    
                    return RedirectToAction("Wall", "Wall");

                }
            }
        }
        else 
        {
            return View("Index");
        }

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
}
