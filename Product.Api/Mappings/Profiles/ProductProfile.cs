using AutoMapper;
using Product.Api.Dtos;

namespace Product.Api.Mappings.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Entities.Product, GetProductInputModel>();
            CreateMap<IEnumerable<Entities.Product>, GetProductOutputModel>().ConstructUsing(products => new GetProductOutputModel(products));
        }
    }
}
