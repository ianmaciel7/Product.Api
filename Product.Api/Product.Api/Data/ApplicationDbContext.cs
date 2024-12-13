using Product.Api.Models;
using Microsoft.EntityFrameworkCore;
using Product.Api.Configurations;

namespace Product.Api.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment env) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Models.Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            if (env.IsDevelopment())
            {
                optionsBuilder.UseInMemoryDatabase("InMemoryDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfiguration(env));
            modelBuilder.ApplyConfiguration(new CategoryConfiguration(env));
        }
    }
}
