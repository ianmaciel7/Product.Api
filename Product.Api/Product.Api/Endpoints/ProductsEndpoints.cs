using Product.Api.Constants;
using Product.Api.Dtos.Reponses;
using Product.Api.Dtos.Requests;
using Product.Api.Services;

namespace Product.Api.Endpoints
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup(Resource.Products)
                              .WithTags(Tag.Products)
                              .ProducesProblem(StatusCodes.Status400BadRequest);

            group.MapGet("{productId}", async (Guid productId, IProductService productService) =>
            {
                return await productService.GetByIdAsync(productId);
            })
            .WithName(Name.GetProductById)
            .Produces<IEnumerable<ProductReponse>>(StatusCodes.Status200OK);

            group.MapPost("", async (ProductRequest product, IProductService productService) =>
            {
                return await productService.CreateAsync(product);
            })
            .Produces<ProductReponse>(StatusCodes.Status200OK);

            group.MapPut("{productId}", async (Guid? productId, ProductRequest product, IProductService productService) =>
            {
                return await productService.UpdateAsync(productId, product);
            })
            .Produces<ProductReponse>(StatusCodes.Status200OK); ;

            group.MapDelete("{productId}", async (Guid productId, IProductService productService) =>
            {
                return await productService.RemoveAsync(productId);
            })
            .Produces<ProductReponse>(StatusCodes.Status200OK); ;
        }
    }
}
