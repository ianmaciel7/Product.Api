using AutoMapper;
using Product.Api.Dtos;
using Product.Api.Repositories;

namespace Product.Api.Services
{
    public class ProductService(IMapper mapper,IProductRepository productRepository) : IProductService
    {
        public GetProductOutputModel Get(GetProductInputModel inputModel)
        {
            var products = productRepository.Get(inputModel).ToList();
            return mapper.Map<GetProductOutputModel>(products);
        }
    }
}
