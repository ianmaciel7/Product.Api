using AutoMapper;
using Product.Api.Dtos;
using Product.Api.Repositories;

namespace Product.Api.Services
{
    internal class ProductService(IUrlService urlService,IMapper mapper,IProductRepository productRepository) : IProductService
    {
        public GetProductsOutputModel Get(GetProductsInputModel inputModel)
        {
            var products = productRepository.Get(inputModel);
            return mapper.Map<GetProductsOutputModel>(products, options =>
            {
                options.Items["urlService"] = urlService;
            });
        }
    }
}
