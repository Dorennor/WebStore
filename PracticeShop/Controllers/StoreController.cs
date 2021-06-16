using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreContextDB _db;
        //private readonly IWebHostEnvironment _appEnvironment;
        private readonly ApplicationContext _userDb;

        public StoreController(StoreContextDB context, /*IWebHostEnvironment appEnvironment,*/ ApplicationContext userContext)
        {
            _db = context;
            //_appEnvironment = appEnvironment;
            _userDb = userContext;
        }

        [HttpGet]
        public IActionResult ShowLibrary() => View(_userGameList);

        [HttpGet]
        public IActionResult GamesList() => View(_db.Games.OrderBy(g => g.Name).ToList());

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult AddGame() => View();

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddGame(Device model)
        {
            if (!CheckStore(model))
            {
                _db.Games.Add(model);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            else return Content("ERROR");
        }

        [HttpPost]
        public IActionResult AddToLibrary(int id) => View("AddToLibrary", AddGameToLibrary(id));

        [HttpPost]
        public IActionResult BuyGame(int id) => View("BuyGame", AddGameToLibrary(id));

        private string AddGameToLibrary(int id)
        {
            if (!IsUserHasLibrary)
            {
                CreateLibraryWithGame(id);
            }
            else
            {
                if (CheckGame(id))
                {
                    return "Игра уже находится в Вашей библиотеке!";
                }

                Write(id);
            }

            return "Игра была добавлена в Вашу библиотеку!";
        }

        private void Write(int id)
        {
            List<Device> games;
            if (_libraryList.First().GamesID == "")
            {
                games = new List<Device>();
                games.Add(_db.Games.Find(id));
                _libraryList.First().GamesID = JsonSerializer.Serialize(games);
                _db.SaveChanges();
            }
            else
            {
                games = JsonSerializer.Deserialize<List<Device>>(_libraryList.First().GamesID);
                games.Add(_db.Games.Find(id));
                _libraryList.First().GamesID = JsonSerializer.Serialize(games);
                _db.SaveChanges();
            }
        }

        private void Delete(int id)
        {
            var games = JsonSerializer.Deserialize<List<Device>>(_libraryList.First().GamesID);
            if (games.Count > 1)
            {
                games.Remove(_db.Games.Find(id));
                _libraryList.First().GamesID = JsonSerializer.Serialize(games);
                _db.SaveChanges();
            }
            else
            {
                _libraryList.First().GamesID = "";
                _db.SaveChanges();
            }
        }

        private bool CheckGame(int id)
        {
            if (_userGameList == null) return false;
            return _userGameList.Where(g => g.ID == id).ToList().Count > 0;
        }

        private bool IsUserHasLibrary => _libraryList.Count >= 1;

        private List<Device> _userGameList
        {
            get
            {
                try
                {
                    return JsonSerializer.Deserialize<List<Device>>(_libraryList.Last().GamesID);
                }
                catch
                {
                    return null;
                }
            }
        }

        private bool CheckStore(Device model)
        {
            var result = _db.Games.Where(g => g.Name == model.Name).ToList();
            if (result.Count > 0) return true;
            else return false;
        }

        private List<Orders> _libraryList => _db.Libraries.Where(l => l.UserID == CurrentUser.Id).ToList();

        private void CreateLibraryWithGame(int id)
        {
            var games = new List<Device> { _db.Games.Find(id) };

            _db.Libraries.Add(new Orders(CurrentUser.Id, JsonSerializer.Serialize(games)));
            _db.SaveChanges();
        }

        public IActionResult DeleteGame() => View(_db.Games.OrderBy(g => g.Name));

        [HttpPost]
        public IActionResult DeleteGame(int id)
        {
            _db.Games.Remove(_db.Games.Where(g => g.ID == id).First());
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult EditGameView() => View(_db.Games.OrderBy(g => g.Name));

        [HttpGet]
        public IActionResult EditGame(int id)
        {
            Device device = _db.Games.Find(id);
            if (device == null)
            {
                return NotFound();
            }

            EditGameViewModel model = new EditGameViewModel { Name = device.Name, Genre = device.Type, Publisher = device.Manufacturer, Price = device.Price };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditGame(EditGameViewModel model)
        {
            Device device = _db.Games.Find(model.Id);
            if (ModelState.IsValid)
            {
                if (device != null)
                {
                    device.Name = model.Name;
                    device.Type = model.Genre;
                    device.Manufacturer = model.Publisher;
                    device.Price = model.Price;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult DeleteGameFromLibrary(int id)
        {
            Delete(id);
            return RedirectToAction("Index", "Home");
        }

        public User CurrentUser
        {
            get
            {
                return _userDb.Users.Where(u => u.UserName == User.Identity.Name).First();
            }
        }
    }
}