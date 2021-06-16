using Microsoft.EntityFrameworkCore;



namespace WebStore.Models
{
    public class StoreContextDB : DbContext
    {
        public DbSet<Device> Games { get; set; }
        public DbSet<Orders> Libraries { get; set; }
        public DbSet<Image> DeviceIcons { get; set; }
        public DbSet<Image> Photos{ get; set; }

        public StoreContextDB(DbContextOptions<StoreContextDB> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}