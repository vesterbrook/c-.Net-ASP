using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using theWall;
using theWall.Models;

namespace theWall.Controllers
{
    public class WallController : Controller 
    {
        
         [HttpGet]
         [Route("success")]
         public IActionResult Success()
         {
             if(HttpContext.Session.GetString("name") == null)
             {
                 return RedirectToAction("Index", "User");
             }
             else{
                 TempData["id"] = HttpContext.Session.GetInt32("id");
                 TempData["name"] = HttpContext.Session.GetString("name");
                 return View("Wall");
             }
         }

        [HttpGet]
        [Route("wall")]
        public IActionResult Wall()
        {
            if(HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                TempData["id"] = HttpContext.Session.GetInt32("id");
                ViewBag.Name = HttpContext.Session.GetString("name");
                int id = (int)HttpContext.Session.GetInt32("id");
                string qMessage = $"SELECT messages.id, messages.user_id, messages.created_at, users.firstName, messages.message FROM messages JOIN users ON messages.user_id WHERE messages.user_id = users.id;";
                var messages = DbConnector.Query(qMessage);
                string qComment = $"SELECT comment, comments.created_at, users.firstName, users.lastName, comments.messages_id FROM comments JOIN users on comments.user_id WHERE (comments.user_id = users.id) ORDER BY comments.created_at ASC;";
                var comments = DbConnector.Query(qComment);
                ViewBag.Messages = messages;
                ViewBag.Comments = comments;
                return View("Wall","Wall");
            }
        }

        [HttpPost]
        [Route("writeMessage")]
        public IActionResult writeMessage(string message)
        {
            int? id = HttpContext.Session.GetInt32("id");
            if(HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToAction("Wall");
            }
            else{
                if(message.Length > 0)
                {
                    int userID = (int)id;
                    string query = $"INSERT INTO messages (message, user_id, created_at, updated_at) VALUES ('{message}', '{userID}', NOW(), NOW());";
                    DbConnector.Execute(query);
                    return RedirectToAction("Wall");
                }
                else{
                    return RedirectToAction("Wall");
                }
            }
        }

          [HttpPost]
          [Route("writeComment")]
          public IActionResult writeComment(string comment, int message_id)
          {
              int? id = HttpContext.Session.GetInt32("id");
              if(HttpContext.Session.GetInt32("id") == null)
              {
                  return RedirectToAction("Wall");
              }
              else
              {
                  if(comment.Length > 0)
                  {
                      int userID = (int)id;
                      string query = $"INSERT INTO comments (user_id, messages_id, comment, created_at) VALUES ('{userID}', '{message_id}', '{comment}', NOW());";
                      System.Console.WriteLine(query);
                      DbConnector.Execute(query);
                      return RedirectToAction("Wall");
                  }
                  else
                  {
                      return RedirectToAction("Wall");
                  }
              }
          }
     }
}