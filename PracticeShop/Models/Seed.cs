using System.Linq;

namespace PracticeShop.Models
{
    public static class Seed
    {
        public static void Initialize(StoreContextDB context)
        {
            if (!context.Games.Any())
            {
                context.AddRange(
                    new Game
                    {
                        Name = "Warframe",
                        Genre = "Экшн",
                        Publisher = "Digital Extremes",
                        Price = 0
                    },
                    new Game
                    {
                        Name = "Death Stranding",
                        Genre = "Экшн",
                        Publisher = "Kojima Productions",
                        Price = 60
                    },
                    new Game
                    {
                        Name = "Mass Effect",
                        Genre = "RPG",
                        Publisher = "BioWare",
                        Price = 40
                    },
                    new Game
                    {
                        Name = "The Elder Scrolls 5: Skyrim",
                        Genre = "RPG",
                        Publisher = "Bethesda Softworks",
                        Price = 20
                    },
                    new Game
                    {
                        Name = "Sekiro: Shadows Die Twice",
                        Genre = "Экшн",
                        Publisher = "From Software",
                        Price = 60
                    },
                    new Game
                    {
                        Name = "Assassin`s Creed",
                        Genre = "Action-adventure",
                        Publisher = "Ubisoft",
                        Price = 20
                    },
                    new Game
                    {
                        Name = "Mass Effect 2",
                        Genre = "RPG",
                        Publisher = "BioWare",
                        Price = 40
                    },
                    new Game
                    {
                        Name = "Mass Effect 3",
                        Genre = "RPG",
                        Publisher = "BioWare",
                        Price = 40
                    },
                    new Game
                    {
                        Name = "Smite",
                        Genre = "Moba",
                        Publisher = "Hi-Rez Studios",
                        Price = 0
                    },
                    new Game
                    {
                        Name = "The Elder Scrolls 4: Oblivion",
                        Genre = "RPG",
                        Publisher = "Bethesda Softworks",
                        Price = 10
                    },
                    new Game
                    {
                        Name = "The Elder Scrolls 3: Morrowind",
                        Genre = "RPG",
                        Publisher = "Bethesda Softworks",
                        Price = 5
                    },
                    new Game
                    {
                        Name = "Assassin`s Creed 2",
                        Genre = "Action-adventure",
                        Publisher = "Ubisoft",
                        Price = 20
                    },
                    new Game
                    {
                        Name = "Assassin`s Creed: Brotherhood",
                        Genre = "Action-adventure",
                        Publisher = "Ubisoft",
                        Price = 20
                    },
                    new Game
                    {
                        Name = "Assassin`s Creed: Revelations",
                        Genre = "Action-adventure",
                        Publisher = "Ubisoft",
                        Price = 20
                    },
                    new Game
                    {
                        Name = "The Elder Scrolls Online",
                        Genre = "MMORPG",
                        Publisher = "Zenimax Online Studios",
                        Price = 40
                    },
                    new Game
                    {
                        Name = "Dota 2",
                        Genre = "Moba",
                        Publisher = "Valve",
                        Price = 0
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}