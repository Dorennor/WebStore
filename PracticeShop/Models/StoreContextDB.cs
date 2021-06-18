using Microsoft.EntityFrameworkCore;



namespace WebStore.Models
{
    public sealed class StoreContextDb : DbContext
    {
        public DbSet<Device> Devices { get; set; }

        public StoreContextDb(DbContextOptions<StoreContextDb> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}