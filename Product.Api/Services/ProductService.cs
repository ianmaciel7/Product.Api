using AutoMapper;
using CommunityToolkit.Diagnostics;
using Product.Api.Dtos;
using Product.Api.Dtos.Base;
using Product.Api.Mappings.Extensions;
using Product.Api.Repositories;

namespace Product.Api.Services
{
    internal class ProductService(IUrlService urlService, IProductRepository productRepository, IMapper mapper) 
        : Service<Entities.Product>(urlService,productRepository,mapper), 
        IProductService
    {
        public IFindProductOutputModel Find(IFindProductInputModel inputModel)
        {
            return FindById<FindProductOutputModel>(inputModel.ProductId);
        }

        public IFindAllProductsOutputModel FindAll(IFindAllProductsInputModel inputModel)
        {
            return FindAllById<FindAllProductsOutputModel>(inputModel.ProductId);
        }

        public IAddProductOutputModel Add(IAddProductInputModel inputModel)
        {
            return base.Add<FindProductOutputModel>(inputModel);
        }

        public IRemoveProductOutputModel Remove(IRemoveProductInputModel inputModel)
        {
            var product = productRepository.FindById(inputModel.ProductId);
            Guard.IsNotNull(product);
            productRepository.Update(product);
            productRepository.SaveChanges();
            return new RemoveProductOutputModel();
        }

        public IUpdateProductOutputModel Update(IUpdateProductInputModel inputModel)
        {
            var product = mapper.Map<Entities.Product>(inputModel);
            productRepository.Update(product);
            productRepository.SaveChanges();
            return mapper.Map<FindProductOutputModel>(product, urlService);
        }
    }
}
