using BibleTreasure.Models;
using BibleTreasure.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BibleTreasure.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITreasure treasure;

        public HomeController(ILogger<HomeController> logger, ITreasure treasure)
        {
            _logger = logger;
            this.treasure = treasure;
        }

        public IActionResult Index()
        {
            treasure.GetTodayTreasure();
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}