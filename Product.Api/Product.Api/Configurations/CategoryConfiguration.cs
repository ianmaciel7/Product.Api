using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Product.Api.Configurations
{
    public class CategoryConfiguration(IWebHostEnvironment env) : IEntityTypeConfiguration<Models.Category>
    {
        public void Configure(EntityTypeBuilder<Models.Category> builder)
        {
           
        }
    }
}
