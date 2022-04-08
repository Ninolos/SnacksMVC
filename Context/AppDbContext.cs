using Microsoft.EntityFrameworkCore;
using SnackMVC.Models;

namespace SnackMVC.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Snack> Snacks { get; set; }

        public DbSet<ShopCartItem> ShopCartItens { get; set; }
    }
}
