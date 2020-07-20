using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeShop.Models
{
    public class StoreContextDB : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Library> Libraries { get; set; }

        public StoreContextDB(DbContextOptions<StoreContextDB> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
