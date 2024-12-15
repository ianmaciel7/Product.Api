using Product.Api.Models;
using Product.Api.Models.ValueObjects;
using Product.Api.Services;

namespace Product.Api.Endpoints.V1
{
    public static class CategoriesEnpoints
    {
        const string Base = "/api/v1/categories";
        public static void MapCategoriesEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("{Base}", async (ICategoryService categoryService) =>
            {        
                return await categoryService.GetAllAsync();
            });
            endpoints.MapGet("{Base}/{categoryId:int}", async (CategoryId categoryId, ICategoryService categoryService) =>
            {
                return await categoryService.GetByIdAsync(categoryId);
            });
            endpoints.MapPost("{Base}", async (Category category, ICategoryService categoryService) =>
            {
                return await categoryService.CreateAsync(category);
            });
            endpoints.MapPut("{Base}/{categoryId:int}", async (CategoryId? categoryId, Category category, ICategoryService categoryService) =>
            {
                return await categoryService.CreateAsync(category);
            });
            endpoints.MapDelete("{Base}/{id}", async (CategoryId categoryId, ICategoryService categoryService) =>
            {
                return await categoryService.RemoveAsync(categoryId);
            });
        }


    }
}
