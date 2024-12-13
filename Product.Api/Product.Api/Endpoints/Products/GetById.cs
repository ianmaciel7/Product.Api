
using Product.Api.Models.ValueObjects;
using Product.Api.Services;

namespace Product.Api.Endpoints.Products
{
    public class GetById : IEndpoint
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (ProductId id, ProductService productService) =>
            {
                var product = await productService.GetByIdAsync(id);
                if (product == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(product);
            });
        }
    }
}
