using System.Linq;

namespace WebStore.Models
{
    public static class Seed
    {
        public static void Initialize(StoreContextDB context)
        {
            if (context.Games.Any()) return;
            context.AddRange(
                new Device
                {
                    Name = "A30",
                    Type = "Smartphone",
                    Manufacturer = "Samsung",
                    Price = 300
                },
                new Device
                {
                    Name = "Death Stranding",
                    Type = "Экшн",
                    Manufacturer = "Kojima Productions",
                    Price = 60
                },
                new Device
                {
                    Name = "Mass Effect",
                    Type = "RPG",
                    Manufacturer = "BioWare",
                    Price = 40
                },
                new Device
                {
                    Name = "The Elder Scrolls 5: Skyrim",
                    Type = "RPG",
                    Manufacturer = "Bethesda Softworks",
                    Price = 20
                },
                new Device
                {
                    Name = "Sekiro: Shadows Die Twice",
                    Type = "Экшн",
                    Manufacturer = "From Software",
                    Price = 60
                },
                new Device
                {
                    Name = "Assassin`s Creed",
                    Type = "Action-adventure",
                    Manufacturer = "Ubisoft",
                    Price = 20
                },
                new Device
                {
                    Name = "Mass Effect 2",
                    Type = "RPG",
                    Manufacturer = "BioWare",
                    Price = 40
                },
                new Device
                {
                    Name = "Mass Effect 3",
                    Type = "RPG",
                    Manufacturer = "BioWare",
                    Price = 40
                },
                new Device
                {
                    Name = "Smite",
                    Type = "Moba",
                    Manufacturer = "Hi-Rez Studios",
                    Price = 0
                },
                new Device
                {
                    Name = "The Elder Scrolls 4: Oblivion",
                    Type = "RPG",
                    Manufacturer = "Bethesda Softworks",
                    Price = 10
                },
                new Device
                {
                    Name = "The Elder Scrolls 3: Morrowind",
                    Type = "RPG",
                    Manufacturer = "Bethesda Softworks",
                    Price = 5
                },
                new Device
                {
                    Name = "Assassin`s Creed 2",
                    Type = "Action-adventure",
                    Manufacturer = "Ubisoft",
                    Price = 20
                },
                new Device
                {
                    Name = "Assassin`s Creed: Brotherhood",
                    Type = "Action-adventure",
                    Manufacturer = "Ubisoft",
                    Price = 20
                },
                new Device
                {
                    Name = "Assassin`s Creed: Revelations",
                    Type = "Action-adventure",
                    Manufacturer = "Ubisoft",
                    Price = 20
                },
                new Device
                {
                    Name = "The Elder Scrolls Online",
                    Type = "MMORPG",
                    Manufacturer = "Zenimax Online Studios",
                    Price = 40
                },
                new Device
                {
                    Name = "Dota 2",
                    Type = "Moba",
                    Manufacturer = "Valve",
                    Price = 0
                }
            );
            context.SaveChanges();
        }
    }
}