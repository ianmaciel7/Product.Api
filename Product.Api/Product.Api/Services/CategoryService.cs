using AutoMapper;
using CommunityToolkit.Diagnostics;
using Product.Api.Dtos;
using Product.Api.Models;
using Product.Api.Repositories;

namespace Product.Api.Services
{
    public class CategoryService(ICategoryRepostiory categoryRepostiory, LinkGenerator linkGenerator, IMapper mapper) : ICategoryService
    {
        private readonly Func<Guid, string?> _generatorUri = (Guid categoryId) => linkGenerator.GetUriByAction(
            httpContext: new DefaultHttpContext(),
            action: "GetCategoryById",
            controller: "Categories",
            values: new { CategoryId = categoryId }
        );

        public async Task<IResult> CreateAsync(CategoryDto dto)
        {
            var entity = mapper.Map<Category>(dto);
            var category = await categoryRepostiory.CreateAsync(entity);
            await categoryRepostiory.SaveAsync();
            Guard.IsNotNull(category, nameof(category));
            var uri = _generatorUri(category!.CategoryId);
            return Results.Created(uri, category);
        }

        public async Task<IResult> GetAllAsync()
        {
            var categories = await categoryRepostiory.GetAllAsync() ?? [];
            return Results.Ok(categories);
        }

        public async Task<IResult> GetAllProductsAsync(Guid categoryId)
        {
            var category = await categoryRepostiory.GetByIdAsync(categoryId);
            if (category is null)
            {
                return Results.NotFound();
            }
            var products = category.Products;
            return Results.Ok(products);
        }

        public async Task<IResult> GetByIdAsync(Guid id)
        {
            var category = await categoryRepostiory.GetByIdAsync(id);
            if (category is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(category);
        }

        public async Task<IResult> RemoveAsync(Guid id)
        {
            var category = await categoryRepostiory.GetByIdAsync(id);
            if (category is null)
            {
                return Results.NotFound();
            }
            Guard.IsNull(category, nameof(category));
            categoryRepostiory.Remove(category!);
            await categoryRepostiory.SaveAsync();
            return Results.NoContent();
        }

        public async Task<IResult> UpdateAsync(Guid? id, CategoryDto dto)
        {
            Guard.IsNotNull(dto, nameof(dto));
            var category = mapper.Map<Category>(dto);
            if (id is null)
            {
                category = await categoryRepostiory.CreateAsync(category);
                var uri = _generatorUri(category!.CategoryId);
                return Results.Created(uri, category);
            }
            category = await categoryRepostiory.GetByIdAsync(id.GetValueOrDefault());
            category = categoryRepostiory.Update(category!);
            return Results.Ok(category);
        }

        public Task<IResult> UpdateAsync(Guid id, CategoryDto dto)
        {
            return UpdateAsync(id, dto);
        }
    }
}
