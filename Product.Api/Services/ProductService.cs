using AutoMapper;
using CommunityToolkit.Diagnostics;
using Product.Api.Dtos;
using Product.Api.Dtos.Base;
using Product.Api.Mappings.Extensions;
using Product.Api.Repositories;

namespace Product.Api.Services
{
    internal class ProductService(IUrlService urlService, IMapper mapper, IProductRepository productRepository) : IProductService
    {
        public IFindProductOutputModel Find(IFindProductInputModel inputModel)
        {
            var product = productRepository.FindById(inputModel.ProductId);
            Guard.IsNotNull(product);
            return mapper.Map<FindProductOutputModel>(product, urlService);
        }

        public IFindAllProductsOutputModel FindAll(IFindAllProductsInputModel inputModel)
        {
            var products = productRepository.FindAllById(inputModel?.ProductId).ToList();
            return mapper.Map<FindAllProductsOutputModel>(products, urlService);
        }

        public IAddProductOutputModel Add(IAddProductInputModel inputModel)
        {
            var product = mapper.Map<Entities.Product>(inputModel);
            productRepository.Add(product);
            productRepository.SaveChanges();
            return mapper.Map<FindProductOutputModel>(product, urlService);
        }

        public IRemoveProductOutputModel Remove(IRemoveProductInputModel inputModel)
        {
            var product = productRepository.FindById(inputModel.ProductId);
            Guard.IsNotNull(product);
            productRepository.Remove(product);
            productRepository.SaveChanges();
            return new RemoveProductOutputModel();
        }
    }
}
