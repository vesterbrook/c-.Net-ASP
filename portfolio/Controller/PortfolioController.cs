using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace portfolio.Controllers
{
    public class portfolioController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            
            return View("Index");
            
        }
        [HttpGet]
        [Route("Contact")]
        public IActionResult Contact()
        {
            
            return View("Contact");
            
        }
        [HttpGet]
        [Route("Projects")]
        public IActionResult Projects()
        {
            
            return View("Projects");
            
        }
    }
}