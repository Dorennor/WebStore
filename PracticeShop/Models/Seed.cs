using System.Linq;

namespace WebStore.Models
{
    public static class Seed
    {
        public static void Initialize(StoreContextDb context)
        {
            if (context.Devices.Any()) return;
            context.AddRange(
                new Device
                {
                   Name = "A30",
                   Manufacturer = "Samsung",
                   Description = "Samsung Galaxy A30 3/32 2019 Blue",
                   Price = 4999,
                   SerialNumber = "SM-A305FZBOSEK",
                   Image = "\\Images\\Devices\\SM-A305FZBOSEK.jpg"
                },
                new Device
                {
                    Name = "iPhone 12 Pro Max",
                    Manufacturer = "Apple",
                    Description = "Apple iPhone 12 Pro Max 256GB Pacific Blue",
                    Price = 48499,
                    SerialNumber = "MGDF3",
                    Image = "\\Images\\Devices\\MGDF3.png"
                },
                new Device
                {
                    Name = "Redmi Note 10 Pro",
                    Manufacturer = "Xiaomi",
                    Description = "Xiaomi Redmi Note 10 Pro 6/128 Glacier Blue",
                    Price = 8999,
                    SerialNumber = "765961",
                    Image = "\\Images\\Devices\\765961.jpg"
                },
                new Device
                {
                    Name = "EO-EG920L Blue",
                    Manufacturer = "Samsung",
                    Description = "Наушники Samsung EO-EG920L Blue",
                    Price = 275,
                    SerialNumber = "EO-EG920LLEGRU",
                    Image = "\\Images\\Devices\\EO-EG920LLEGRU.jpg"
                },
                new Device
                {
                    Name = "AirPods with Charging Case 2 gen",
                    Manufacturer = "Apple",
                    Description = "Навушники Apple AirPods with Charging Case 2 gen",
                    Price = 3750,
                    SerialNumber = "MV7N2RU",
                    Image = "\\Images\\Devices\\MV7N2RU.jpg"
                }

            );
            context.SaveChanges();
        }
    }
}