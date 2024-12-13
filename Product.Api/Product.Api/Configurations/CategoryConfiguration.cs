using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Api.Models.ValueObjects;

namespace Product.Api.Configurations
{
    public class CategoryConfiguration(IWebHostEnvironment env) : IEntityTypeConfiguration<Models.Category>
    {
        public void Configure(EntityTypeBuilder<Models.Category> builder)
        {
            builder.HasKey(c => c.CategoryId);

            builder.Property(c => c.CategoryId)
                .HasConversion(
                    v => v.ToString(),
                    v => new CategoryId(Guid.Parse(v))
                );

            builder.Property(c => c.ParentId)
                .HasConversion(
                    v => v != null ? v.Value.ToString() : null,
                    v => v == null ? null : new CategoryId(Guid.Parse(v))
                );

        }
    }
}
