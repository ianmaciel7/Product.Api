using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Api.Models.ValueObjects;

namespace Product.Api.Configurations
{
    public class ProductConfiguration(IWebHostEnvironment env) : IEntityTypeConfiguration<Models.Product>
    {
        public void Configure(EntityTypeBuilder<Models.Product> builder)
        {
            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.CategoryId)
                .HasConversion(
                    v => v.ToString(),
                    v => new CategoryId(Guid.Parse(v))
                );

        }
    }
}
