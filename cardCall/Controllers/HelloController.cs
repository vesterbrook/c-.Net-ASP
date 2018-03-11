using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace cardCall.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("/{firstName}/{lastName}/{age}/{faveColor}")]
        public JsonResult Display(string firstName, string lastName, int age, string faveColor)
        {
            var card = new {
                            firstName = firstName,
                            lastName = lastName,
                            age = age,
                            faveColor = faveColor
                            
                            };

            return Json(card);
        }
    }
}