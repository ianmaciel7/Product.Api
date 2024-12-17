using Product.Api.Dtos.Requests;
using Product.Api.Services;

namespace Product.Api.Endpoints.V1
{
    public static class CategoriesEnpoints
    {

        public static void MapCategoriesEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup("v1/categories").WithTags("Categories");

            group.MapGet("", async (ICategoryService categoryService) =>
            {
                return await categoryService.GetAllAsync();
            });

            group.MapGet("{categoryId}", async (Guid categoryId, ICategoryService categoryService) =>
            {
                return await categoryService.GetByIdAsync(categoryId);
            }).WithName("GetCategoryById");

            group.MapPost("", async (CategoryRequest category, ICategoryService categoryService) =>
            {
                return await categoryService.CreateAsync(category);
            });

            group.MapPut("{categoryId}", async (Guid? categoryId, CategoryRequest category, ICategoryService categoryService) =>
            {
                return await categoryService.UpdateAsync(categoryId, category);
            });

            group.MapDelete("{categoryId}", async (Guid categoryId, ICategoryService categoryService) =>
            {
                return await categoryService.RemoveAsync(categoryId);
            });

            group.MapGet("{categoryId}/products", async (Guid categoryId, ICategoryService categoryService) =>
            {
                return await categoryService.GetAllProductsAsync(categoryId);
            });
        }
    }
}
