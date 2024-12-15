
using Product.Api.Models.ValueObjects;
using Product.Api.Repositories;
using CommunityToolkit.Diagnostics;


namespace Product.Api.Services
{
    public class ProductService(IProductRepository productRepository,LinkGenerator linkGenerator) : IProductService
    {

        private Func<ProductId, string?> _generatorUri = (productId) => linkGenerator.GetUriByAction(
            httpContext: new DefaultHttpContext(),
            action: "GetProductById",
            controller: "Products",
            values: new { ProductId = productId.Value }
        );

        public async Task<IResult> CreateAsync(Models.Product entity)
        {
            var product = await productRepository.CreateAsync(entity);
            Guard.IsNull(product, nameof(product));
            var uri = _generatorUri(product!.ProductId);
            return Results.Created(uri, product);
        }

        public async Task<IResult> RemoveAsync(ProductId id)
        {
            Guard.IsNotNull(id, nameof(id));
            var product = await productRepository.GetByIdAsync(id);
            if (product is null)
            {
                return Results.NotFound();
            }
            Guard.IsNull(product, nameof(product));
            productRepository.Remove(product!);
            return Results.NoContent();
        }

        public async Task<IResult> GetAllAsync()
        {
            var products = await productRepository.GetAllAsync() ?? [];
            return Results.Ok(products);
        }

        public async Task<IResult> GetByIdAsync(ProductId id)
        {
            Guard.IsNotNull(id, nameof(id));
            var product = await productRepository.GetByIdAsync(id);
            Guard.IsNull(product, nameof(product));
            if (product is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(product);
        }

        public async Task<IResult> UpdateAsync(ProductId? productId, Models.Product product)
        {
            Guard.IsNull(product, nameof(product));
            if (productId is null)
            {
                Guard.IsNull(product, nameof(product));
                var created = await productRepository.CreateAsync(product);  
                var uri = _generatorUri(created!.ProductId);
                return Results.Created(uri, created);
            }
            var entity = await productRepository.GetByIdAsync(productId);
            Guard.IsNull(entity, nameof(entity));
            var updated = productRepository.Update(product);
            return Results.Ok(updated);
        }

        public async Task<IResult> GetAllAsync(CategoryId categoryId)
        {
            Guard.IsNotNull(categoryId, nameof(categoryId));
            var products = await productRepository.GetAllByCategoryIdAsync(categoryId) ?? [];
            return Results.Ok(products);
        }
    }
}
