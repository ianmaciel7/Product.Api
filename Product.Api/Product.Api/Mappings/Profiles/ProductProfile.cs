using AutoMapper;

namespace Product.Api.Mappings.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Models.Product, Dtos.ProductDto>();
            CreateMap<Dtos.ProductDto, Models.Product>();
        }
    }
}
