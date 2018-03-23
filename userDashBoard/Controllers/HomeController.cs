using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using userDashBoard.Models;

namespace userDashBoard.Controllers
{
    public class HomeController : Controller
    {
        private UserContext _context;
 
        public HomeController(UserContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser(RegUser newRegUser)
        {
            if (ModelState.IsValid)
            {
                User current = _context.Users.SingleOrDefault(RegUser => RegUser.Email == newRegUser.Email);
                if(current != null)
                {
                    ModelState.AddModelError("Email", "Email already exists!");
                    return View("Index");
                }
                else
                {
                    List<User> firstUser = _context.Users.ToList();
                    if(firstUser.Count == 0)
                    {
                        PasswordHasher<RegUser> Hasher = new PasswordHasher<RegUser>();
                        string hashed = Hasher.HashPassword(newRegUser, newRegUser.Password);
                        User user = new User
                        {
                            FirstName = newRegUser.FirstName,
                            LastName = newRegUser.LastName,
                            Email = newRegUser.Email,  
                            Password = hashed,
                            created_at = DateTime.Now,
                            UserLevel = 9 
                        };
                        _context.Add(user);
                        _context.SaveChanges();
                        User sessionuser = _context.Users.Where(u => u.Email == newRegUser.Email).SingleOrDefault();
                        HttpContext.Session.SetInt32("userID", sessionuser.UserId);
                        HttpContext.Session.SetString("firstname", sessionuser.FirstName);
                        return RedirectToAction("AdminDash");
                    }
                    else
                    {
                        PasswordHasher<RegUser> Hasher = new PasswordHasher<RegUser>();
                        string hashed = Hasher.HashPassword(newRegUser, newRegUser.Password);
                        User user = new User
                        {
                            FirstName = newRegUser.FirstName,
                            LastName = newRegUser.LastName,
                            Email = newRegUser.Email,  
                            Password = hashed,    
                        };
                        _context.Add(user);
                        _context.SaveChanges();
                        User sessionuser = _context.Users.Where(u => u.Email == newRegUser.Email).SingleOrDefault();
                        HttpContext.Session.SetInt32("userID", sessionuser.UserId);
                        HttpContext.Session.SetString("firstname", sessionuser.FirstName);
                        return RedirectToAction("UserDash");
                    }
                }
            }
            else
            {
                return View("Index");
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
            if(ModelState.IsValid)
            {
                User current = _context.Users.Where(u => u.Email == loginUser.Email).SingleOrDefault();
                if(current == null)
                {
                    ModelState.AddModelError("Email", "Email does not exist!");
                    return View("Login");
                }
                else
                {
                    if(current.UserLevel == 9)
                    {
                        var hasher = new PasswordHasher<User>();
                        if(hasher.VerifyHashedPassword(current, current.Password, loginUser.Password) == 0)
                        {
                            ModelState.AddModelError("Password", "Incorrect password!");
                            return View("Login");
                        }
                        else
                        {
                            HttpContext.Session.SetInt32("userID", current.UserId);
                            HttpContext.Session.SetString("firstname", current.FirstName);
                            return RedirectToAction("AdminDash");
                        }
                    }
                    else
                    {
                        var hasher = new PasswordHasher<User>();
                        if(hasher.VerifyHashedPassword(current, current.Password, loginUser.Password) == 0)
                        {
                            ModelState.AddModelError("Password", "Incorrect password!");
                            return View("Login");
                        }
                        else
                        {
                            HttpContext.Session.SetInt32("userID", current.UserId);
                            HttpContext.Session.SetString("firstname", current.FirstName);
                            return RedirectToAction("UserDash");
                        }
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

        [HttpGet]
        [Route("Add")]
        public IActionResult AdminAddUserView()
        {
            return View("Add");
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AdminAddedUser(RegUser newAddUser)
        {
            PasswordHasher<RegUser> Hasher = new PasswordHasher<RegUser>();
            string hashed = Hasher.HashPassword(newAddUser, newAddUser.Password);
            User user = new User
            {
                FirstName = newAddUser.FirstName,
                LastName = newAddUser.LastName,
                Email = newAddUser.Email,  
                Password = hashed,
                created_at = DateTime.Now,
                
            };
            _context.Add(user);
            _context.SaveChanges();
            
            return RedirectToAction("AdminDash");
            
        }

        [HttpGet]
        [Route("admindash")]
        public IActionResult AdminDash()
        {
            List<User> allUsers = _context.Users.ToList();
            ViewBag.AllUsers = allUsers;
            int? banana = HttpContext.Session.GetInt32("userID");
            ViewBag.Banana = banana;
            return View("Manage");
        }

        [HttpGet]
        [Route("userdash")]
        public IActionResult UserDash()
        {
            List<User> allUsers = _context.Users.ToList();
            ViewBag.AllUsers = allUsers;
            int? banana = HttpContext.Session.GetInt32("userID");
            ViewBag.Banana = banana;
            return View("Dash");
        }

        [HttpGet]
        [Route("edituser/{id}")]
        public IActionResult EditUser(int id)
        {
            User specificUser = _context.Users.SingleOrDefault(s => s.UserId == id);
            ViewBag.EditUser = specificUser;
            return View("EditUser");
        }

        [HttpPost]
        [Route("edituser/{id}")]
        public IActionResult EditUserProcess(RegUser editUser, int id)
        {
            User user = _context.Users.SingleOrDefault (u => u.UserId == id);
            user.FirstName = editUser.FirstName;
            user.LastName = editUser.LastName;
            user.Email = editUser.Email;
            user.UserLevel = editUser.UserLevel;
            _context.SaveChanges ();
            return RedirectToAction("AdminDash");
        }

        [HttpPost]
        [Route("edituserpw/{id}")]
        public IActionResult EditUserPWProcess(RegUser editUser, int id)
        {
            User user = _context.Users.SingleOrDefault (u => u.UserId == id);
            user.Password = editUser.Password; //need to hash pw
            _context.SaveChanges ();
            return RedirectToAction("AdminDash");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            User user = _context.Users.SingleOrDefault(u => u.UserId == id);
            _context.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("AdminDash");
        }

        [HttpGet]
        [Route("manage")]
        public IActionResult Manage()
        {return View("Manage");}

        [HttpGet]
        [Route("show/{id}")]
        public IActionResult Show(int id)
        {
            HttpContext.Session.SetInt32("Profile", id);
            List<Message> myMessages = _context.Messages.Where(m => m.ProfileId == id).ToList();
            ViewBag.VBAG = myMessages;
            User friends = _context.Users.SingleOrDefault(s => s.UserId == id);
            ViewBag.Friends = friends;
            
            return View("Show");
        }
        [HttpPost]
        [Route("Message")]
        public IActionResult Message(Message newMessage)

        {     
            int? id = HttpContext.Session.GetInt32("userID");
            Message apple = new Message
            {
                UserId = (int) id,
                ProfileId = Convert.ToInt32(HttpContext.Session.GetInt32("Profile")),
                Messages = newMessage.Messages,
                created_at = DateTime.Now,
            };
            _context.Add(apple);
            _context.SaveChanges();
            return RedirectToAction("Show");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
