using Product.Api.Models.ValueObjects;
using Product.Api.Services;

namespace Product.Api.Endpoints.V1
{
    public static class ProductEndpoints
    {
        public const string Base = "/api/v1/products";

        public static void MapProductEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet($"{Base}/{{productId:int}}", async (ProductId productId, IProductService productService) =>
            {
                return await productService.GetByIdAsync(productId);
            }).WithName("GetProductById");

            routes.MapPost(Base, async (Models.Product product,IProductService productService)  =>
            {
                return await productService.CreateAsync(product);
            });

            routes.MapPut($"{Base}/{{productId:int?}}", async (ProductId? productId,Models.Product product,IProductService productService) =>
            {
                return await productService.UpdateAsync(productId, product);
            });

            routes.MapDelete($"{Base}/{{productId:int}}", async (ProductId productId,IProductService productService) =>
            {
                return await productService.RemoveAsync(productId);
            });
        }
    }
}
