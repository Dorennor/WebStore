using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebStore.Models
{
    public sealed class ApplicationContext : IdentityDbContext<User>
    {
        //public DbSet<string> Image { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}