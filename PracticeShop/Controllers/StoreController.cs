using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticeShop.Models;

namespace PracticeShop.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreContextDB _db;

        public StoreController(StoreContextDB context)
        {
            _db = context;
        }

        [HttpGet]
        public IActionResult ShowLibrary() => View(_userGameList);

        [HttpGet]
        public IActionResult GamesList() => View(_db.Games.OrderBy(g => g.Name).ToList());

        [HttpGet]
        [Authorize(Roles = "Администратор")]
        public IActionResult AddGame() => View();

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> AddGame(Game model)
        {
            _db.Games.Add(model);
            await _db.SaveChangesAsync();
            return RedirectToAction("Store");
        }

        [HttpPost]
        public IActionResult AddToLibrary(int gameID) => View("AddToLibrary", AddGameToLibrary(gameID));

        [HttpPost]
        public IActionResult BuyGame(int gameID) => View("BuyGame", AddGameToLibrary(gameID));

        private string AddGameToLibrary(int gameID)
        {
            if (!IsUserHasLibrary)
            {
                CreateLibraryWithGame(gameID);
            }
            else
            {
                if (CheckGame(gameID))
                {
                    return "Игра уже находится в Вашей библиотеке!";
                }

                Write(gameID);
            }

            return "Игра была добавлена в Вашу библиотеку!";
        }

        private void Write(int gameID)
        {
            List<Game> games = JsonSerializer.Deserialize<List<Game>>(_libraryList.Last().GamesID);
            games.Add(_db.Games.Find(gameID));
            _libraryList.FirstOrDefault().GamesID = JsonSerializer.Serialize(games);
            _db.SaveChanges();
        }

        private bool CheckGame(int gameID) => _userGameList.Where(g => g.ID == gameID).ToList().Count > 0;

        private bool IsUserHasLibrary => _libraryList.Count >= 1;

        private List<Game> _userGameList => JsonSerializer.Deserialize<List<Game>>(_libraryList.Last().GamesID);

        private List<Library> _libraryList => _db.Libraries.Where(l => l.UserName == User.Identity.Name).ToList();

        private void CreateLibraryWithGame(int gameID)
        {
            var games = new List<Game> { _db.Games.Find(gameID) };

            _db.Libraries.Add(new Library(User.Identity.Name, JsonSerializer.Serialize(games)));
            _db.SaveChanges();
        }
    }
}
