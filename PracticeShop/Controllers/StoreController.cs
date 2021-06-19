using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class StoreController : Controller
    {
        private static UserBin finalBin;
        private static List<Device> _bin;
        private StoreContextDb _db { get; }
        private ApplicationContext _users;

        public StoreController(StoreContextDb context, ApplicationContext users)
        {
            _db = context;
            _users = users;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var devices = _db.Devices.ToList();
            return View(devices);
        }

        private bool CheckStore(Device model) => _db.Devices.Where(g => g.Name == model.Name).ToList().Count > 0;


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddDevice(Device model)
        {
            if (!CheckStore(model))
            {
                _db.Devices.Add(model);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Store");
            }
            else return Content("ERROR");
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel
            {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});

        [HttpGet]
        public IActionResult SearchItem()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchItem(string searchQuery)
        {
            var devices = _db.Devices.Where(l =>
                l.Name.Contains(searchQuery) || l.Description.Contains(searchQuery) ||
                l.SerialNumber.Contains(searchQuery) || l.Manufacturer.Contains(searchQuery)).ToList();
            return View("SearchResult", devices);
        }

        [HttpGet]
        public IActionResult ShowTransactions()
        {
            Debug.WriteLine(_db.Transactions.First().UserName);
            return View(_db.Transactions);
        }

        [HttpPost]
        public IActionResult AddToBin(int id)
        {
            _bin ??= new List<Device>();
            _bin.Add(_db.Devices.Find(id));
            Debug.WriteLine(_bin.Count);
            return RedirectToAction("Index", "Store");
        }

        [HttpPost]
        public IActionResult DeleteFromBin(int id)
        {
            _bin.Remove(_bin.Where(l => l.Id.Equals(id)).ToList().First());
            return RedirectToAction("Index", "Store");
        }

        private Device Apriori()
        {
            var transactionsCount = _db.Transactions.Count();
            double countSupp;
            double countConf = 0;
            Device temp = new Device();
      
            List<AprioriStats> stats = _db.Devices.Select(device => new AprioriStats {Device = device}).ToList();

            var transactions = _db.Transactions.ToList();
            var devices = _db.Devices.ToList();
            var item = _bin[new Random().Next(0, _bin.Count - 1)];

            foreach (var transaction in transactions)
            {
                if (transaction.SerialNumber.Contains(item.SerialNumber))
                {
                    countConf++;
                }
            }
         
            foreach (var device in devices)
            {
                countSupp = 0;
                foreach (var transaction in transactions)
                {
                    if (transaction.SerialNumber.Contains(item.SerialNumber) &&
                        transaction.SerialNumber.Contains(device.SerialNumber))
                    {
                        countSupp++;
                    }
                    stats.Where(l => l.Device.SerialNumber == device.SerialNumber).First().Support = countSupp / transactionsCount;
                    stats.Where(l => l.Device.SerialNumber == device.SerialNumber).First().Confidence = countConf / countSupp;
                    stats.Where(l => l.Device.SerialNumber == device.SerialNumber).First().Lift =
                        stats.Where(l => l.Device.SerialNumber == device.SerialNumber).First().Support /
                        stats.Where(l => l.Device.SerialNumber == device.SerialNumber).First().Confidence
                        ;
                }
            }
            
            double previousRes = 0;

            foreach (var device in stats)
            {
                if (device.Device.SerialNumber.Contains(item.SerialNumber)) continue;
                
                if (previousRes < device.Lift)
                {
                    previousRes = device.Lift;
                    temp = device.Device;
                }
            }
            return temp;
        }

        [HttpGet]
        public IActionResult UserBin()
        {
            finalBin = new UserBin(_bin, Apriori());
            return View(finalBin);
        }

        [HttpPost]
        public IActionResult Buy()
        {
            List<string> serialNumbers = new List<string>();
            List<double> prices = new List<double>();

            foreach (var i in _bin)
            {
                serialNumbers.Add(i.SerialNumber);
                prices.Add(i.Price);
            }
            _db.Transactions.AddRange(
                new Transaction
                {
                    UserName = User.Identity.Name,
                    Date = DateTime.Now.ToString(CultureInfo.CurrentCulture),
                    SerialNumber = JsonSerializer.Serialize(serialNumbers),
                    Price = JsonSerializer.Serialize(prices)
                });
            _db.SaveChanges();
            _bin.Clear();
            return RedirectToAction("Index");
        }


        
    }
}

//[HttpGet]
        //public IActionResult DevicePage(int id)
        //{

        //}

        //[HttpPost]
    //    public IActionResult EditGame(EditDevieViewModel model)
    //    {
    //        Device device = _db.Devices.Find(model.Id);
    //        if (ModelState.IsValid)
    //        {
    //            if (device != null)
    //            {
    //                device.Name = model.Name;
    //                device.Type = model.Genre;
    //                device.Manufacturer = model.Publisher;
    //                device.Price = model.Price;
    //                _db.SaveChanges();
    //            }
    //        }
    //        return RedirectToAction("Index", "Home");
    //    }
    //}
//}


//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using WebStore.Models;
//using WebStore.ViewModels;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.Json;
//using System.Threading.Tasks;
//using WebStore.Models;

//namespace WebStore.Controllers
//{
//    public class StoreController : Controller
//    {
//        private readonly StoreContextDb _db;
//        //private readonly IWebHostEnvironment _appEnvironment;
//        private readonly ApplicationContext _userDb;
//        private Bin bin;

//        public StoreController(StoreContextDb context, /*IWebHostEnvironment appEnvironment,*/ ApplicationContext userContext)
//        {
//            _db = context;
//            //_appEnvironment = appEnvironment;
//            _userDb = userContext;
//            bin = new Bin();
//        }

//        [HttpGet]
//        public IActionResult ShowTransactions() => View(_userGameList);

//        [HttpGet]
//        public IActionResult DevicesList() => View(_db.Devices.OrderBy(g => g.Name).ToList());

//        [HttpGet]
//        [Authorize(Roles = "admin")]
//        public IActionResult AddDevice() => View();

//        

//        //[HttpPost]
//        //public IActionResult AddToLibrary(int id) => View("AddToLibrary", AddDeviceToBin(id));

//        //[HttpPost]
//        //public IActionResult BuyGame(int id) => View("BuyGame", AddDeviceToBin(id));

//        [HttpPost]
//        private void AddDeviceToBin(int id)
//        {
//            bin.AddToBin(_db.Devices.Find(id));
//        }

//        private void Write(int id)
//        {
//            List<Device> devices;
//            if (_libraryList.First().GamesID == "")
//            {
//                devices = new List<Device>();
//                devices.Add(_db.Devices.Find(id));
//                _libraryList.First().GamesID = JsonSerializer.Serialize(devices);
//                _db.SaveChanges();
//            }
//            else
//            {
//                devices = JsonSerializer.Deserialize<List<Device>>(_libraryList.First().GamesID);
//                devices.Add(_db.Devices.Find(id));
//                _libraryList.First().GamesID = JsonSerializer.Serialize(devices);
//                _db.SaveChanges();
//            }
//        }

//        private void Delete(int id)
//        {
//            var games = JsonSerializer.Deserialize<List<Device>>(_libraryList.First().GamesID);
//            if (games.Count > 1)
//            {
//                games.Remove(_db.Devices.Find(id));
//                _libraryList.First().GamesID = JsonSerializer.Serialize(games);
//                _db.SaveChanges();
//            }
//            else
//            {
//                _libraryList.First().GamesID = "";
//                _db.SaveChanges();
//            }
//        }

//        private bool CheckGame(int id)
//        {
//            if (_userGameList == null) return false;
//            return _userGameList.Where(g => g.Id == id).ToList().Count > 0;
//        }

//        private bool IsUserHasLibrary => _libraryList.Count >= 1;

//        private List<Device> _userGameList
//        {
//            get
//            {
//                try
//                {
//                    return JsonSerializer.Deserialize<List<Device>>(_libraryList.Last().GamesID);
//                }
//                catch
//                {
//                    return null;
//                }
//            }
//        }

//        

//        private List<Orders> _libraryList => _db.Libraries.Where(l => l.UserID == CurrentUser.Id).ToList();

//        private void CreateLibraryWithGame(int id)
//        {
//            var games = new List<Device> { _db.Devices.Find(id) };

//            _db.Libraries.Add(new Orders(CurrentUser.Id, JsonSerializer.Serialize(games)));
//            _db.SaveChanges();
//        }

//        public IActionResult DeleteGame() => View(_db.Devices.OrderBy(g => g.Name));

//        [HttpPost]
//        public IActionResult DeleteGame(int id)
//        {
//            _db.Devices.Remove(_db.Devices.Where(g => g.ID == id).First());
//            _db.SaveChanges();
//            return RedirectToAction("Index", "Home");
//        }

//        public IActionResult EditGameView() => View(_db.Devices.OrderBy(g => g.Name));

//        [HttpGet]
//        public IActionResult EditGame(int id)
//        {
//            Device device = _db.Devices.Find(id);
//            if (device == null)
//            {
//                return NotFound();
//            }

//            EditDevieViewModel model = new EditDevieViewModel { Name = device.Name, Genre = device.Type, Publisher = device.Manufacturer, Price = device.Price };
//            return View(model);
//        }



//        [HttpPost]
//        public IActionResult DeleteGameFromLibrary(int id)
//        {
//            Delete(id);
//            return RedirectToAction("Index", "Home");
//        }

//        public User CurrentUser
//        {
//            get
//            {
//                return _userDb.Users.First(u => u.UserName == User.Identity.Name);
//            }
//        }
//    }
//}