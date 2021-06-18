//using Microsoft.AspNetCore.Mvc;
//using WebStore.Models;
//using System.Diagnostics;
//using System.Linq;

//namespace WebStore.Controllers
//{
//    public class HomeController : Controller
//    {
//        private StoreContextDb _db;

//        public HomeController(StoreContextDb context)
//        {
//            _db = context;
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            var devices = _db.Devices.ToList().GetRange(_db.Devices.ToList().Count - 10, 10);
//            devices.Reverse();
//            return View(devices);
//        }

//        public IActionResult Privacy() => View();

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//    }
//}