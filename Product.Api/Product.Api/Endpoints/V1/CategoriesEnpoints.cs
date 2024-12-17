using Product.Api.Constants;
using Product.Api.Dtos.Reponses;
using Product.Api.Dtos.Requests;
using Product.Api.Services;

namespace Product.Api.Endpoints.V1
{
    public static class CategoriesEnpoints
    {
        public static void MapCategoriesEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup("v1/categories")
                                 .WithTags(Tag.Categories)
                                 .ProducesProblem(StatusCodes.Status400BadRequest);

            group.MapGet("", async (ICategoryService categoryService) =>
            {
                return await categoryService.GetAllAsync();
            })
            .Produces<IEnumerable<CategoryReponse>>(StatusCodes.Status200OK);

            group.MapGet("{categoryId}", async (Guid categoryId, ICategoryService categoryService) =>
            {
                return await categoryService.GetByIdAsync(categoryId);
            })
            .WithName(Name.GetCategoryById)
            .Produces<CategoryReponse>(StatusCodes.Status200OK);

            group.MapPost("", async (CategoryRequest category, ICategoryService categoryService) =>
            {
                return await categoryService.CreateAsync(category);
            })
            .Produces<CategoryReponse>(StatusCodes.Status200OK);

            group.MapPut("{categoryId}", async (Guid? categoryId, CategoryRequest category, ICategoryService categoryService) =>
            {
                return await categoryService.UpdateAsync(categoryId, category);
            })
            .Produces<CategoryReponse>(StatusCodes.Status200OK);

            group.MapDelete("{categoryId}", async (Guid categoryId, ICategoryService categoryService) =>
            {
                return await categoryService.RemoveAsync(categoryId);
            })
            .Produces<CategoryReponse>(StatusCodes.Status200OK);

            group.MapGet("{categoryId}/products", async (Guid categoryId, ICategoryService categoryService) =>
            {
                return await categoryService.GetAllProductsAsync(categoryId);
            })
            .Produces<CategoryReponse>(StatusCodes.Status200OK);
        }
    }
}
