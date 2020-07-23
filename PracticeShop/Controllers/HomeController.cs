using Microsoft.AspNetCore.Mvc;
using PracticeShop.Models;
using System.Diagnostics;
using System.Linq;

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