using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace portfolio.Controllers
{
    public class TimeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            
            return View("Index");
            
        }
    }
}