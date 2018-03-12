using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace dojodachi.controllers
{
    public class DojodachiController : Controller

    {
        //root 
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
                if(HttpContext.Session.GetObjectFromJson<Tomagachi>("DojoData") == null)
                {
                    HttpContext.Session.SetObjectAsJson("DojoData", new Tomagachi());
                }
                ViewBag.DojoData = HttpContext.Session.GetObjectFromJson<Tomagachi>("DojoData");
                    if(ViewBag.DojoData.fullness < 1 || ViewBag.DojoData.happiness < 1) {
                        ViewBag.DojoData.status = "Your tomagachi is no longer with us";
                    }
                    if(ViewBag.DojoData.fullness > 100 && ViewBag.DojoData.happiness > 100 && ViewBag.DojoData.energy > 100){
                        ViewBag.DojoData.status = "Your tomagachi is living its best life";
                    }
                return View();
        }

        //reset 
        [HttpGet]
        [Route("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        //feed meeee
        [HttpGet]
        [Route("feed")]
        public IActionResult FeedTomagachi()
        {
            Tomagachi CurrDojoData = HttpContext.Session.GetObjectFromJson<Tomagachi>("DojoData");
            if(CurrDojoData.meals > 0){
                CurrDojoData.feed();
            } else {
                CurrDojoData.status = "No meals. Get to work!";
            }
            HttpContext.Session.SetObjectAsJson("Dojodata", CurrDojoData);
            return RedirectToAction("Index");
        }

        //sleep
        [HttpGet]
        [Route("sleep")]
        public IActionResult SleepTomagachi()
        {
            Tomagachi CurrDojoData = HttpContext.Session.GetObjectFromJson<Tomagachi>("DojoDachi");
            CurrDojoData.sleep();
            HttpContext.Session.SetObjectAsJson("DojoData",CurrDojoData);
            return RedirectToAction("Index");
        }

        //play

        [HttpGet]
        [Route("play")]
        public IActionResult PlayTomagachi()
        {
            Tomagachi CurrDojoData = HttpContext.Session.GetObjectFromJson<Tomagachi>("DojoData");
             if(CurrDojoData.energy > 0){
                CurrDojoData.play();
            } else {
                CurrDojoData.status = "Too tired to play. Time for a nap!";
            }
            HttpContext.Session.SetObjectAsJson("DojoData",CurrDojoData);
            return RedirectToAction("Index");
        }   

        //work
           [HttpGet]
        [Route("work")]
        public IActionResult WorkTomagachi()
        {
            Tomagachi CurrDojoData = HttpContext.Session.GetObjectFromJson<Tomagachi>("DojoData");
             if(CurrDojoData.energy > 0){
                CurrDojoData.work();
            } else {
                CurrDojoData.status = "Too tired to work! Time for a nap.";
            }
            HttpContext.Session.SetObjectAsJson("DojoData",CurrDojoData);
            return RedirectToAction("Index");
        }
    public static class SessionExtensions
    {
        
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
           
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        
       
    }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
        
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

    }
}
