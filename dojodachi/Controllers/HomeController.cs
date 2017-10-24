using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using dojodachi;

namespace dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        [Route("/initiate/")]
        public IActionResult About()
        {
            HttpContext.Session.Clear();
            Dachi dachi = new Dachi();
            HttpContext.Session.SetObjectAsJson("dachi", dachi);          
            return RedirectToAction("Game");
        }

        public IActionResult Game()
        {
            Dachi dachi = HttpContext.Session.GetObjectFromJson<Dachi>("dachi");
            ViewBag.happiness = dachi.happiness;
            ViewBag.fullness = dachi.fullness;
            ViewBag.energy = dachi.energy;
            ViewBag.meals = dachi.meals;
            if(TempData["done"] != null)
            {
                ViewBag.done = TempData["done"];
            }
            else
            {
                ViewBag.done = "false";
            }
            if(TempData["message"] != null)
            {
                ViewBag.message = TempData["message"];
            }
            else
            {
                ViewBag.message = "Choose an action";
            }

            return View();
        }

        [HttpPost]
        [Route("act/")]
        public IActionResult Act(string act)
        {
            Dachi dachi = HttpContext.Session.GetObjectFromJson<Dachi>("dachi");
            if(act == "Feed"){
                TempData["message"] = dachi.feeding();
            }
            if(act=="Play")
            {
                TempData["message"] = dachi.playing(); 
            }
            if(act=="Work")
            {
                TempData["message"] = dachi.working(); 
            }
            if(act=="Sleep")
            {
                TempData["message"] = dachi.sleeping();
            }
            string done = dachi.isDone();
            if(done == "win")
            {
                TempData["done"] = "true";
                TempData["message"] = "Congratulations! You won!";
            } 
            else if(done == "dead")
            {
                TempData["done"] = "true";
                TempData["message"] = "Your dachi ded";
            }
            else
            {
                TempData["done"] = "false";
            }
            HttpContext.Session.SetObjectAsJson("dachi", dachi); 
            return RedirectToAction("Game");
        }
    }
}
