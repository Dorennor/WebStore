using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PracticeShop.Models;

namespace PracticeShop.Controllers
{
    public class HomeController : Controller
    {
        private StoreContextDB _db;

        public HomeController(StoreContextDB context)
        {
            _db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var games = _db.Games.ToList().GetRange(_db.Games.ToList().Count - 10, 10);
            games.Reverse();
            return View(games);
        }
        
        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
