using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Product.Api.Data.Configurations
{
    public class CategoryConfiguration(IWebHostEnvironment env) : IEntityTypeConfiguration<Entities.Category>
    {
        private readonly IWebHostEnvironment _env = env;

        public void Configure(EntityTypeBuilder<Entities.Category> builder)
        {

            builder.HasKey(p => p.CategoryId);
            builder.Property(p => p.CategoryId).ValueGeneratedOnAdd();

            if (_env.IsDevelopment())
            {
                builder.HasData(
                    new Entities.Category
                    {
                        CategoryId = 1,
                        Name = "Categoria Padrão 1",
                        Description = "Descrição da Categoria Padrão 1",
                        Products = [],
                        SubCategories = []
                    },
                    new Entities.Category
                    {
                        CategoryId = 2,
                        Name = "Categoria Padrão 2",
                        Description = "Descrição da Categoria Padrão 2",
                        Products = [],
                        SubCategories = []
                    }
                );
            }          
        }
    }
}
