using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.Api.Data.Configurations
{
    public class ProductConfiguration(IWebHostEnvironment env) : IEntityTypeConfiguration<Entities.Product>
    {
        private readonly IWebHostEnvironment _env = env;

        public void Configure(EntityTypeBuilder<Entities.Product> builder)
        {

            builder.Navigation(p => p.Category).AutoInclude();

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
