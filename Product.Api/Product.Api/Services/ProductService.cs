
using Product.Api.Models.ValueObjects;
using Product.Api.Repositories;
using CommunityToolkit.Diagnostics;

namespace Product.Api.Services
{
    public class ProductService(ProductRepository productRepository) : IProductService
    {
        public async Task<Models.Product> CreateAsync(Models.Product entity)
        {
            var product = await productRepository.CreateAsync(entity);
            Guard.IsNull(product, nameof(product));
            return product!;
        }

        public async Task<bool> RemoveAsync(ProductId id)
        {
            Guard.IsNotNull(id, nameof(id));
            var product = await productRepository.GetByIdAsync(id);
            Guard.IsNull(product, nameof(product));
            return productRepository.Remove(product!);
        }

        public Task<IEnumerable<Models.Product>> GetAllAsync()
        {
            return productRepository.GetAllAsync();
        }

        public Task<Models.Product> GetByIdAsync(ProductId id)
        {
            Guard.IsNotNull(id, nameof(id));
            var product = productRepository.GetByIdAsync(id);
            Guard.IsNull(product, nameof(product));
            return product!;
        }

        public async Task<Models.Product> UpdateAsync(ProductId? productId, Models.Product product)
        {
            Guard.IsNull(product, nameof(product));
            if (productId is null)
            {
                Guard.IsNull(product, nameof(product));
                var created = await productRepository.CreateAsync(product);
                return created!;
            }
            var entity = await productRepository.GetByIdAsync(productId);
            Guard.IsNull(entity, nameof(entity));
            return productRepository.Update(entity!);
        }

        public async Task<IEnumerable<Models.Product>> GetAllAsync(CategoryId categoryId)
        {
            Guard.IsNotNull(categoryId, nameof(categoryId));
            var products = await productRepository.GetAllByCategoryIdAsync(categoryId);
            Guard.IsNull(products, nameof(products));
            return products ?? [];
        }
    }
}
