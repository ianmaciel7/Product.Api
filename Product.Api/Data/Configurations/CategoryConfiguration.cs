using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Api.Data.Entities;

namespace Product.Api.Data.Configurations
{
    public class CategoryConfiguration(IWebHostEnvironment env) : IEntityTypeConfiguration<Category>
    {
        private readonly IWebHostEnvironment _env = env;

        public void Configure(EntityTypeBuilder<Category> builder)
        {


            if (_env.IsDevelopment())
            {
                builder.HasData(
                    new Category
                    {
                        CategoryId = 1,
                        Name = "Main Category 1",
                        Description = "Main Category 1 Description"
                    },
                    new Category
                    {
                        CategoryId = 3,
                        Name = "Main Category 3",
                        Description = "Main Category 3 Description",
                        ParentId = 1
                    },
                    new Category
                    {
                        CategoryId = 4,
                        Name = "Sub Category 1",
                        Description = "Sub Category 1 Description",
                        ParentId = 3,
                    },
                    new Category
                    {
                        CategoryId = 5,
                        Name = "Sub Category 2",
                        Description = "Sub Category 2 Description",
                        ParentId = 1
                    }
                );
            }
        }
    }
}
