using AutoMapper;
using CommunityToolkit.Diagnostics;
using Product.Api.Dtos;
using Product.Api.Models;
using Product.Api.Models.ValueObjects;
using Product.Api.Repositories;

namespace Product.Api.Services
{
    public class CategoryService(ICategoryRepostiory categoryRepostiory, LinkGenerator linkGenerator, IMapper mapper) : ICategoryService
    {
        private readonly Func<CategoryId, string?> _generatorUri = (CategoryId categoryId) => linkGenerator.GetUriByAction(
            httpContext: new DefaultHttpContext(),
            action: "GetCategoryById",
            controller: "Categories",
            values: new { CategoryId = categoryId }
        );


        public async Task<IResult> CreateAsync(Category entity)
        {
            var category = await categoryRepostiory.CreateAsync(entity);
            Guard.IsNotNull(category, nameof(category));
            var uri = _generatorUri(category!.CategoryId);
            return Results.Created(uri, category);
        }

        public Task<IResult> CreateAsync(CategoryDto category)
        {
            return CreateAsync(mapper.Map<Category>(category));
        }

        public async Task<IResult> GetAllAsync()
        {
            var categories = await categoryRepostiory.GetAllAsync() ?? [];
            return Results.Ok(categories);
        }

        public async Task<IResult> GetAllProductsAsync(CategoryId categoryId)
        {
            var category = await categoryRepostiory.GetByIdAsync(categoryId);
            if (category is null)
            {
                return Results.NotFound();
            }
            var products = category.Products;
            return Results.Ok(products);
        }

        public async Task<IResult> GetByIdAsync(CategoryId id)
        {
            var category = await categoryRepostiory.GetByIdAsync(id);
            if (category is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(category);
        }

        public async Task<IResult> RemoveAsync(CategoryId id)
        {
            var category = await categoryRepostiory.GetByIdAsync(id);
            if (category is null)
            {
                return Results.NotFound();
            }
            Guard.IsNull(category, nameof(category));
            categoryRepostiory.Remove(category!);
            return Results.NoContent();
        }

        public async Task<IResult> UpdateAsync(CategoryId? productId, Category category)
        {
            Guard.IsNotNull(category, nameof(category));
            if (productId is null)
            {
                category = await categoryRepostiory.CreateAsync(category);
                var uri = _generatorUri(category!.CategoryId);
                return Results.Created(uri, category);
            }
            category = await categoryRepostiory.GetByIdAsync(productId);
            category = categoryRepostiory.Update(category!);
            return Results.Ok(category);

        }

        public Task<IResult> UpdateAsync(CategoryId categoryId, CategoryDto dto)
        {
           var category = mapper.Map<Category>(dto);
           return UpdateAsync(categoryId, category);
        }
    }
}
