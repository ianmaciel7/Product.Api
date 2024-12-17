using Product.Api.Dtos.Requests;
using Product.Api.Services;

namespace Product.Api.Endpoints.V1
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("v1/products").WithTags("Products");

            group.MapGet("{productId}", async (Guid productId, IProductService productService) =>
            {
                return await productService.GetByIdAsync(productId);
            }).WithName("GetProductById");

            group.MapPost("", async (ProductRequest product, IProductService productService) =>
            {
                return await productService.CreateAsync(product);
            });

            group.MapPut("{productId}", async (Guid? productId, ProductRequest product, IProductService productService) =>
            {
                return await productService.UpdateAsync(productId, product);
            });

            group.MapDelete("{productId}", async (Guid productId, IProductService productService) =>
            {
                return await productService.RemoveAsync(productId);
            });
        }
    }
}
