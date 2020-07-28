using Microsoft.EntityFrameworkCore;

namespace PracticeShop.Models
{
    public class StoreContextDB : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Image> GameIcons { get; set; }
        public DbSet<Image> Screenshots { get; set; }

        public StoreContextDB(DbContextOptions<StoreContextDB> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}