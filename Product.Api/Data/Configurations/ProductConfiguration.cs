using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product.Api.Data.Entities.ValueObjects;

namespace Product.Api.Data.Configurations
{
    public class ProductConfiguration(IWebHostEnvironment env) : IEntityTypeConfiguration<Entities.Product>
    {
        private readonly IWebHostEnvironment _env = env;

        public void Configure(EntityTypeBuilder<Entities.Product> builder)
        {
            builder.HasKey(c => c.ProductId);

            var categoryIdConverter = new ValueConverter<CategoryId, int>(
               id => id.Value,
               value => new CategoryId(value)
           );
            var productIdConverter = new ValueConverter<ProductId, int>(
                id => id.Value,
                value => new ProductId(value)
            );
            builder.Property(c => c.ProductId).HasConversion(productIdConverter).ValueGeneratedOnAdd();
            builder.Property(c => c.CategoryId).HasConversion(categoryIdConverter);


            if (_env.IsDevelopment())
            {
                builder.HasData(
                    new Entities.Product
                    {
                        ProductId = 1,
                        Name = "Product 1",
                        Description = "Product 1 Description",
                        Price = 100,
                        CategoryId = 1
                    },
                    new Entities.Product
                    {
                        ProductId = 2,
                        Name = "Product 2",
                        Description = "Product 2 Description",
                        Price = 200,
                        CategoryId = 2
                    }
                );
            }
        }
    }
}
