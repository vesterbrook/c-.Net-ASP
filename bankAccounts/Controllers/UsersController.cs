using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using bankAccounts.Models;

namespace bankAccounts.Controllers
{
    public class UsersController : Controller
{
    private BankContext _context;
 
    public UsersController(BankContext context)
    {
        _context = context;
    }            

    [HttpGet]
    [Route("")]
    public IActionResult Index()
        {
            return View();
        }

    [HttpPost]
    [Route("createUser")]
    public IActionResult createUser(Register regUser)
    {
        if(ModelState.IsValid)
        {
            User exists = _context.Users.SingleOrDefault(user => user.Email == regUser.Email);
            if(exists != null)
            {
                return View("Index");
            }
            else
            {
                PasswordHasher<Register> Hasher = new PasswordHasher<Register>();
                string hashed = Hasher.HashPassword(regUser, regUser.Password);
                User newUser = new User
                {
                    FirstName = regUser.FirstName,
                    LastName = regUser.LastName,
                    Password = hashed,
                    Email = regUser.Email,
                    Balance = 0.00
                };
                _context.Add(newUser);
                _context.SaveChanges();
                User user = _context.Users.Where(u => u.Email == regUser.Email).SingleOrDefault();
                HttpContext.Session.SetInt32("userId", user.UserId);
                HttpContext.Session.SetString("userName", user.FirstName);
                return RedirectToAction("Account");

            }
        }
        else
        {
            return View("Index");

        }          

    }

    [HttpGet]
    [Route("login")]
    public IActionResult LoginPage()
        {
            return View("Login");
        }

    [HttpPost]
    [Route("loginUser")]
    public IActionResult LoginUser(Login loginUser)
    {
        if(ModelState.IsValid)
        {
        User exists = _context.Users.Where(u => u.Email == loginUser.Email).SingleOrDefault();
        if(exists == null)
        {
        return View("Login");
        }
        else
        {
            var hasher = new PasswordHasher<User>();
            if(hasher.VerifyHashedPassword(exists, exists.Password, loginUser.Password) == 0)
            {
                return View("Login");
            }
            else
            {
            HttpContext.Session.SetInt32("userId", exists.UserId);
            HttpContext.Session.SetString("userName", exists.FirstName);
            return RedirectToAction("Account", "Accounts");
            }
        }
            
        }
    else
    {
        return View("Login");
    }
    }

    [HttpPost]
    [Route("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();

        return RedirectToAction("Index");
    }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

