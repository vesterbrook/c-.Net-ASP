using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ajaxNotes.Models;

namespace ajaxNotes.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index(string title, string note)
        {   
            var users = DbConnector.Query("SELECT * FROM ajaxNotes");
            ViewBag.List = users;
            foreach(var user in ViewBag.List)
            {
                ViewBag.Title = user["title"];
                ViewBag.Note = user["note"];
            }
            return View();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult NoteAdded(string title, string note)
        {
            string t = title;
            string n = note;
            string insertQ = $"INSERT INTO ajaxNotes(title, note) VALUES('{t}', '{n}')";
            DbConnector.Execute(insertQ);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult Update(int id, string title, string note)
        {
            string t = title;
            string n = note;
            string u = $"UPDATE ajaxNotes SET title='{t}', note='{n}' WHERE id={id}";
            DbConnector.Execute(u);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult UpdateEdit(int id, string title, string note)
        {
            var users = DbConnector.Query($"SELECT * FROM ajaxNotes WHERE id='{id}'");
            ViewBag.List = users;
            foreach(var user in users)
            {
                ViewBag.Title = user["title"];
                ViewBag.Note = user["note"];
            }
            return View("Update");
        }
        [HttpPost]
        [Route("delete/{id}")]

        public IActionResult Delete(int id)
        {
            string d = $"DELETE FROM ajaxNotes WHERE id={id}";
            DbConnector.Execute(d);
            return RedirectToAction("Index");
        }

        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}
