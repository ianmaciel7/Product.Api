using AutoMapper;
using Product.Api.Dtos;
using Product.Api.Dtos.Base;
using Product.Api.Repositories;

namespace Product.Api.Services
{
    internal class ProductService(IUrlService urlService,IMapper mapper,IProductRepository productRepository) : IProductService
    {
        public IFindProductOutputModel Find(IFindProductInputModel inputModel)
        {
            var product = productRepository.FindById(inputModel.ProductId);
            return mapper.Map<FindProductOutputModel>(product, options =>
            {
                options.Items["urlService"] = urlService;
            });
        }

        public IFindAllProductsOutputModel FindAll(IFindAllProductsInputModel inputModel)
        {
            var products = productRepository.FindAllById(inputModel?.ProductId).ToList();
            return mapper.Map<FindAllProductsOutputModel>(products, options =>
            {
                options.Items["urlService"] = urlService;
            });
        }

        public IAddProductOutputModel Add(IAddProductInputModel inputModel)
        {
            var product = mapper.Map<Entities.Product>(inputModel);
            productRepository.Add(product);
            productRepository.SaveChanges();
            return mapper.Map<FindProductOutputModel>(product, options =>
            {
                options.Items["urlService"] = urlService;
            });
        }
    }
}
