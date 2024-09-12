using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.Api.Data.Configurations
{
    public class ProductConfiguration(IWebHostEnvironment env) : IEntityTypeConfiguration<Entities.Product>
    {
        private readonly IWebHostEnvironment _env = env;

        public void Configure(EntityTypeBuilder<Entities.Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductId).ValueGeneratedOnAdd();

            if (_env.IsDevelopment())
            {
            }
        }
    }
}
