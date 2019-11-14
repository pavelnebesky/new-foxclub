using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using foxClub.Models;
using foxClub.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace foxClub.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {

        FoxServices foxServices;

        public HomeController(FoxServices foxServices)
        {
            this.foxServices = foxServices;
        }

        // GET: /<controller>/
        //[Route("home")]
        public IActionResult Index(string name)
        {
            if (name == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View(foxServices.FindFoxByName(name));
        }

        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(string name)
        {
            foxServices.foxes.Add(new Fox(name));
            //Response.Redirect("/?name="+name);
            return RedirectToAction("Index", "Home", new { name = name }); //anonymous object
        }

        [Route("nutritionstore")]

        public IActionResult NutritionStore(string name)
        {
            ViewBag.foodTypes = foxServices.foodTypes;
            ViewBag.drinks = foxServices.drinks;
            
            return View(foxServices.FindFoxByName(name));
        }

        [Route("nutritionstore")]
        [HttpPost]
        public IActionResult NutritionStore(string name, string food, string drink)
        {
            foxServices.FindFoxByName(name).drink = drink;
            foxServices.FindFoxByName(name).food = food;
            return RedirectToAction("Index", "Home", new { name = name });
        }

        [Route("trickcenter")]

        public IActionResult TrickCenter(string name)
        {
            
            ViewBag.skills = foxServices.skills;
            return View(foxServices.FindFoxByName(name));
        }

        [Route("trickcenter")]
        [HttpPost]
        public IActionResult TrickCenter(string name, string skill)
        {
            foxServices.FindFoxByName(name).tricks.Add(skill);
          
            return RedirectToAction("Index", "Home", new { name = name });
        }

    }
}
