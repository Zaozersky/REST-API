using Microsoft.EntityFrameworkCore;
using Trial.WebAPI.Data.Models;

namespace Trial.WebAPI.Data
{
    public partial class MainDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./../Trial.WebAPI/products.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>().HasKey(cp => new { cp.CategoryId, cp.ProductId });
            SeedData(modelBuilder);
        }

        public DbSet<Brand> Brands { get;set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
    }
}
