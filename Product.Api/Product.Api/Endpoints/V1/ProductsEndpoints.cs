using Product.Api.Models.ValueObjects;
using Product.Api.Services;

namespace Product.Api.Endpoints.V1
{
    public static class ProductEndpoints
    {
        public const string Base = "/api/v1/categories";
        public const string Products = "products";

        public static void MapProductEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet($"{Base}/{{categoryId:int}}/{Products}", async (CategoryId categoryId,IProductService productService) =>
            {
                var products = await productService.GetAllAsync(categoryId);
                return Results.Ok(products);
            });

            routes.MapGet($"{Base}/{Products}/{{productId:int}}", async (ProductId productId, IProductService productService) =>
            {
                var product = await productService.GetByIdAsync(productId);
                return product is not null ? Results.Ok(product) : Results.NotFound();
            });

            routes.MapPost(Base, async (Models.Product product,IProductService productService)  =>
            {
                var created = await productService.CreateAsync(product);
                return Results.Created($"{Base}/{Products}/{product.ProductId}", created);
            });

            routes.MapPut($"{Base}/{{productId:int?}}", async (ProductId? productId,Models.Product product,IProductService productService) =>
            {
                if (productId is null)
                {
                    return Results.Created($"{Base}/{Products}/{product.ProductId}", await productService.CreateAsync(product));
                }

                var updated = await productService.UpdateAsync(productId,product);
                return Results.Ok(updated);
            });

            routes.MapDelete($"{Base}/{Products}/{{productId:int}}", async (ProductId productId,IProductService productService) =>
            {
                var product = await productService.RemoveAsync(productId);
                return Results.NoContent();
            });
        }
    }
}
