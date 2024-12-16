using Product.Api.Dtos;
using Product.Api.Models.ValueObjects;
using Product.Api.Services;

namespace Product.Api.Endpoints.V1
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("v1/products").WithTags("Products");

            group.MapGet("{productId}", async (ProductId productId, IProductService productService) =>
            {
                return await productService.GetByIdAsync(productId);
            }).WithName("GetProductById");

            group.MapPost("", async (ProductDto product, IProductService productService) =>
            {
                return await productService.CreateAsync(product);
            });

            group.MapPut("{productId}", async (ProductId? productId, ProductDto product, IProductService productService) =>
            {
                return await productService.UpdateAsync(productId, product);
            });

            group.MapDelete("{productId}", async (ProductId productId, IProductService productService) =>
            {
                return await productService.RemoveAsync(productId);
            });
        }
    }
}
