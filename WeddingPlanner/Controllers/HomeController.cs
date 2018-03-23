using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private PlanContext _context;
 
        public HomeController(PlanContext context) // For HomeController to be able to use PlanContext
        {
            _context = context; // Needed to Query stuff
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index"); // Renders an HTML view
        }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser(RegUser newRegUser) // This Method takes in a parameter of newRegUser
        {
            if (ModelState.IsValid) // There are NO errors
            {
                User current = _context.Users.SingleOrDefault(e => e.Email == newRegUser.Email); // Query to check if there is an existing email
                if(current != null) // If the results come up with something...
                {
                    ModelState.AddModelError("Email", "Email already exists!"); // ...An email exists and renders the Index View
                    // This is an example of another way to add errors without using ViewBag
                    // The parameters: ModelState.AddModelError("The attribute NAME on the form where you want to put it", "Error Message");
                    return View("Index");
                }
                else // If email does not exist in the database yet...
                {
                    PasswordHasher<RegUser> Hasher = new PasswordHasher<RegUser>(); // This will hash the password
                    string hashed = Hasher.HashPassword(newRegUser, newRegUser.Password); // This will take in the user's given password and hash it
                    User user = new User // Creating a new User using the info provided by the user via the form
                    {
                        FirstName = newRegUser.FirstName,
                        LastName = newRegUser.LastName,
                        Email = newRegUser.Email,  
                        Password = hashed,    
                    };
                    _context.Add(user); // Instant Query to ADD! 
                    _context.SaveChanges(); // Query to Save Changes
                    User sessionuser = _context.Users.Where(u => u.Email == newRegUser.Email).SingleOrDefault(); // Model User has a variable sessionuser that contains the query of getting the new user's email to gain access to their other info
                    HttpContext.Session.SetInt32("userID", sessionuser.UserId); // Setting userID to hold onto the user's UserId while in session
                    HttpContext.Session.SetString("firstname", sessionuser.FirstName); // Setting firstname to hold th user's FirstName while in session
                    return RedirectToAction("Dash"); // Goes to the Method named Dash
                }
            }
            else // If there ARE errors present...
            {
                return View("Index"); // ...Go back to the Index view
                // When you want to show errors, DO NOT Redirect!
            }
        }

        [HttpGet]
        [Route("login")]
        public IActionResult LoginView()
        {
            return View("Login");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser(LoginUser loginUser)
        {
            if(ModelState.IsValid) // If there are NO errors
            {
                User current = _context.Users.Where(u => u.Email == loginUser.Email).SingleOrDefault(); // Query to look for an email in the database
                if(current == null) // If the email does not exist in the database...
                {
                    ModelState.AddModelError("Email", "Email does not exist!"); // ...this will append the new error on the view
                    // This is an example of another way to add errors without using ViewBag
                    // The parameters: ModelState.AddModelError("The attribute NAME on the form where you want to put it", "Error Message");
                    return View("Login");
                }
                else // If email DOES exist
                {
                    var hasher = new PasswordHasher<User>(); // This will hash the password
                    if(hasher.VerifyHashedPassword(current, current.Password, loginUser.Password) == 0) // This will hash the password and look for a matching the email AND hashed password in the database
                    {
                        ModelState.AddModelError("Password", "Incorrect password!"); // This will append the new error on the view
                        return View("Login");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("userID", current.UserId); // Settion session
                        HttpContext.Session.SetString("firstname", current.FirstName); // Setting session
                        return RedirectToAction("Dash");
                    }
                }
            }
            else // If there ARE errors
            {
                return View("Login"); // Go back to the Login view
            }
        }

        [HttpGet]
        [Route("overview/{Weddingid}")]
        public IActionResult Overview(int Weddingid) // This Method shows you the details of a specific wedding, this Method takes in 1 parameter
        {
            Planner oneWedding = _context.Planners.SingleOrDefault (w => w.WeddingId == Weddingid); // Model Planner has a variable named oneWedding that contains a Query to find a wedding with a sepcific WeddingId
            ViewBag.WeddingInfo = oneWedding; // Containing all the results of the Query oneWedding into a ViewBag for use in the HTML
            List<Planner> guests = _context.Planners.Where (w => w.WeddingId == Weddingid).Include (r => r.Guests).ThenInclude (u => u.user).ToList (); // Model Planner will return a List that has a variable named guests that contains a query to find a specific WeddingId to gain access to their Guests and User
            ViewBag.AllGuests = guests; // Containing all the results of the Query guests into a ViewBag for use in the HTML
            return View("Overview");
        }

        [HttpPost]
        [Route("planner")]
        public IActionResult Planner(CreateWedding newPlan) // This Method will create a new Wedding, this Method takes in 1 parameter
        {
            if(ModelState.IsValid) // If there are NO errors
            {
                int? id = HttpContext.Session.GetInt32("userID"); // Getting session information
                Planner planner = new Planner // Creating a new Wedding using the info provided by the user via the forms
                {
                    UserId = (int)id,
                    WedderOne = newPlan.WedderOne,
                    WedderTwo = newPlan.WedderTwo,
                    WeddingDate = newPlan.WeddingDate,
                    Address = newPlan.Address
                };
                User user = _context.Users.Where(u => u.UserId == planner.UserId).SingleOrDefault();
                _context.Add(planner); // Instant Query to ADD!
                _context.SaveChanges(); // Query to Save Changes
                return RedirectToAction("Dash");
            }
            else // If there ARE errors
            {
                return View("Create");
            }
        }
       
        [HttpGet]
        [Route("CreateWedding")]
        public IActionResult CreateWedding() // Method to SHOW the form where the user can create a Wedding
        {
            return View("Create");
        }

        [HttpGet]
        [Route("dash")]
        public IActionResult Dash() // This Method will SHOW a list of Weddings and their basic information
        {
            int? UserId = HttpContext.Session.GetInt32("userID"); // Containing the SessionId in a variable
            List<User> user = _context.Users.Include(u => u.Planners).ToList(); // User Model will return a List and has a variable named user that contains a query 
            List<Planner> allWeddings = _context.Planners.Include(u => u.Guests).Include(u => u.user).ToList();
            List<Guest> guests = _context.Guests.Include(u => u.planner).ThenInclude(u => u.user).ToList();
            ViewBag.AllWeddings = allWeddings;
            User banana = _context.Users.SingleOrDefault (u => u.UserId == UserId);
            ViewBag.UserId = UserId; // The SessionId is stored in here for use in the HTML
            ViewBag.user = banana; // This ViewBag will contain all the results of the banana query
            return View("Dash");
        }

        [HttpGet]
        [Route("rsvp/{WeddingId}")]
        public IActionResult Rsvp(int GuestId, int WeddingId)
        {
            Guest RSVP = new Guest
            {
                UserId = (int)HttpContext.Session.GetInt32("userID"),
                WeddingId = WeddingId
            };
            Guest existingGuest = _context.Guests.SingleOrDefault(r => r.UserId == (int)HttpContext.Session.GetInt32("userID") && r.WeddingId == WeddingId);
            if (existingGuest == null)
            {
                _context.Guests.Add(RSVP);
                _context.SaveChanges();
            }
            return RedirectToAction("Dash");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            Planner RetrievedWedding = _context.Planners.SingleOrDefault(w => w.WeddingId == id);
            _context.Remove(RetrievedWedding);
            _context.SaveChanges();
            return RedirectToAction("Dash");
        }

        [HttpGet]
        [Route("unrsvp/{WeddingId}")]
        public IActionResult Unrsvp(int WeddingId)
        {
            int? Session = HttpContext.Session.GetInt32("userID");
            Guest banana = _context.Guests.Where(r=> r.WeddingId == WeddingId).Where(u => u.UserId == Session).SingleOrDefault();
            _context.Remove(banana);
            _context.SaveChanges();
            return RedirectToAction("Dash");
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}