using Microsoft.EntityFrameworkCore;

namespace PracticeShop.Models
{
    public class ImagesDBContext : DbContext
    {
        public DbSet<Image> UserIcons { get; set; }
        public DbSet<Image> GameIcons { get; set; }
        public DbSet<Image> Screenshots { get; set; }

        public ImagesDBContext(DbContextOptions<ImagesDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}