using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarWarsAPILab.Models;

namespace StarWarsAPILab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PersonSearch(int selection)
        {
            StarWarsDAL db = new StarWarsDAL();

            Person Jedi = await db.GetPerson(selection);
            ViewBag.Type = "Person";

            return View("Index", Jedi);
        }

        public async Task<IActionResult> PlanetSearch(int selection)
        {
            StarWarsDAL db = new StarWarsDAL();

            Planet Home = new Planet();

            Home = await db.GetPlanet("https://swapi.co/api/planets/" + Convert.ToString(selection) + "/");
            ViewBag.Type = "Planet";

            return View("ResultPlanet", Home);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
