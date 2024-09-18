using AutoMapper;
using Product.Api.Dtos;
using Product.Api.Repositories;

namespace Product.Api.Services
{
    internal class ProductService(IUrlService urlService,IMapper mapper,IProductRepository productRepository) : IProductService
    {
        public FindProductOutputModel Find(FindProductInputModel inputModel)
        {
            var product = productRepository.Find(inputModel);
            return mapper.Map<FindProductOutputModel>(product, options =>
            {
                options.Items["urlService"] = urlService;
            });
        }

        public FindAllProductsOutputModel FindAll(FindAllProductsInputModel inputModel)
        {
            var products = productRepository.FindAll(inputModel).ToList();
            return mapper.Map<FindAllProductsOutputModel>(products, options =>
            {
                options.Items["urlService"] = urlService;
            });
        }
    }
}
