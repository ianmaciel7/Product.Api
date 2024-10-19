using Microsoft.EntityFrameworkCore;
using Product.Api.Data.Configurations;
using Product.Api.Data.Entities;

namespace Product.Api.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment env) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Entities.Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);           
            modelBuilder.ApplyConfiguration(new ProductConfiguration(env));
            modelBuilder.ApplyConfiguration(new CategoryConfiguration(env));
        }
    }
}
