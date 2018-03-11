using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace survey.Controllers
{
    public class surveyController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            
            return View("Index");
            
        }
        [HttpPost]
        [Route("results")]
        public IActionResult Results(string name, string location, string language, string comment)
        {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;
            return View("results");
            
        }
        
    }
}