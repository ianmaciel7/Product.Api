using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Api.Data.Entities.Categories;

namespace Product.Api.Data.Configurations
{
    public class CategoryConfiguration(IWebHostEnvironment env) : IEntityTypeConfiguration<Category>
    {
        private readonly IWebHostEnvironment _env = env;

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Navigation(p => p.Products).AutoInclude();

            if (_env.IsDevelopment())
            {
                builder.HasData(
                    new Category {
                        CategoryId=1,
                        Name="Main Category 1",
                        Description= "Main Category 1 Description", 
                    },
                    new Category
                    {
                        CategoryId = 2,
                        Name="Main Category 2",
                        Description= "Main Category 2 Description",
                        ParentId = 1
                    },
                    new Category
                    {
                        CategoryId = 3,
                        Name="Main Category 3",
                        Description= "Main Category 3 Description",
                    }
                );

                
            }
        }
    }
}
