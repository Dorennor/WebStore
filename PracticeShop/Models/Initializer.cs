using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeShop.Models
{
    public static class Initializer
    {
        public static void Initialize(StoreContextDB context)
        {
            if(!context.Games.Any())
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
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
