using Product.Api.Repositories;
using CommunityToolkit.Diagnostics;
using AutoMapper;
using Product.Api.Dtos.Requests;

namespace Product.Api.Services
{
    public class ProductService(IProductRepository productRepository, LinkGenerator linkGenerator, IMapper mapper) : IProductService
    {

        private Func<Guid, string?> _generatorUri = (productId) => linkGenerator.GetUriByAction(
            httpContext: new DefaultHttpContext(),
            action: "GetProductById",
            controller: "Products",
            values: new { ProductId = productId }
        );

        public async Task<IResult> CreateAsync(ProductRequest dto)
        {
            var entity = mapper.Map<Models.Product>(dto);
            await productRepository.CreateAsync(entity);
            await productRepository.SaveAsync();
            Guard.IsNull(entity, nameof(entity));

            var uri = _generatorUri(entity!.ProductId);
            return Results.Created(uri, entity);
        }

        public async Task<IResult> GetAllAsync()
        {
            var entites = await productRepository.GetAllAsync() ?? [];
            return Results.Ok(entites);
        }

        public async Task<IResult> GetByIdAsync(Guid id)
        {
            Guard.IsNotNull(id, nameof(id));
            var entity = await productRepository.GetByIdAsync(id);
            Guard.IsNull(entity, nameof(entity));
            if (entity is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(entity);
        }

        public async Task<IResult> RemoveAsync(Guid id)
        {
            Guard.IsNotNull(id, nameof(id));
            var entity = await productRepository.GetByIdAsync(id);
            if (entity is null)
            {
                return Results.NotFound();
            }
            Guard.IsNull(entity, nameof(entity));
            productRepository.Remove(entity!);
            await productRepository.SaveAsync();
            return Results.NoContent();
        }

        public async Task<IResult> UpdateAsync(Guid? id, ProductRequest dto)
        {
            var entity = mapper.Map<Models.Product>(dto);
            Guard.IsNull(entity, nameof(entity));
            if (id is null)
            {
                entity = await productRepository.CreateAsync(entity);
                await productRepository.SaveAsync();
                var uri = _generatorUri(entity!.ProductId);
                return Results.Created(uri, entity);
            }

            entity = await productRepository.GetByIdAsync(id.GetValueOrDefault());
            Guard.IsNull(entity, nameof(entity));
            productRepository.Update(entity!);
            await productRepository.SaveAsync();
            return Results.Ok(entity);
        }

        public Task<IResult> UpdateAsync(Guid id, ProductRequest dto)
        {
            return UpdateAsync(id, dto);
        }
    }
}
