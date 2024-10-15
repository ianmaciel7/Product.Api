using Product.Api.Data;
using Product.Api.Data.Entities;
using Product.Api.Data.Entities.ValueObjects;
using Product.Api.IntegrationTest.Fakes;

namespace Product.Api.IntegrationTest.Extensions
{
    public static class DBContextExtensions
    {
        public static ApplicationDbContext GenerateProduct(this ApplicationDbContext dbContext, out Entities.Product product)
        {
            var newProduct = ProductFaker.GenerateDefault();
            dbContext.Set<Entities.Product>().Add(newProduct);
            dbContext.SaveChanges();
            product = newProduct;
            return dbContext;
        }

        public static Category FindRandomCategory(this ApplicationDbContext dbContext, ISet<CategoryId>? skip = null)
        {
            var categories = dbContext.Categories
                    .Where(c => skip == null || !skip.Contains(c.CategoryId))
                    .ToList();

            var c = categories.Count == 0 ? null : categories[new Random().Next(categories.Count)];
            return c;
        }
    }
}
