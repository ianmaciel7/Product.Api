
using Product.Api.Models.ValueObjects;
using Product.Api.Repositories;
using CommunityToolkit.Diagnostics;
using AutoMapper;
using Product.Api.Dtos;


namespace Product.Api.Services
{
    public class ProductService(IProductRepository productRepository,LinkGenerator linkGenerator, IMapper? mapper) : IProductService
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
            await productRepository.SaveAsync();
            Guard.IsNull(product, nameof(product));
            var uri = _generatorUri(product!.ProductId);
            return Results.Created(uri, product);
        }

        public async Task<IResult> RemoveAsync(ProductId? id)
        {
            Guard.IsNotNull(id, nameof(id));
            var product = await productRepository.GetByIdAsync(id);
            if (product is null)
            {
                return Results.NotFound();
            }
            Guard.IsNull(product, nameof(product));
            productRepository.Remove(product!);
            await productRepository.SaveAsync();
            return Results.NoContent();
        }

        public async Task<IResult> GetAllAsync()
        {
            var products = await productRepository.GetAllAsync() ?? [];
            return Results.Ok(products);
        }

        public async Task<IResult> GetByIdAsync(ProductId? id)
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
                product = await productRepository.CreateAsync(product);
                await productRepository.SaveAsync();
                var uri = _generatorUri(product!.ProductId);
                return Results.Created(uri, product);
            }

            product = await productRepository.GetByIdAsync(productId);
            Guard.IsNull(product, nameof(product));
            var updated = productRepository.Update(product!);
            await productRepository.SaveAsync();
            return Results.Ok(updated);
        }

        public async Task<IResult> GetAllAsync(CategoryId? categoryId)
        {
            Guard.IsNotNull(categoryId, nameof(categoryId));
            var products = await productRepository.GetAllByCategoryIdAsync(categoryId) ?? [];
            return Results.Ok(products);
        }

        public Task<IResult> CreateAsync(ProductDto product)
        {
           return CreateAsync(mapper?.Map<Models.Product>(product));
        }

        public Task<IResult> UpdateAsync(ProductId? productId, ProductDto product)
        {
            return UpdateAsync(productId, mapper?.Map<Models.Product>(product));
        }
    }
}
