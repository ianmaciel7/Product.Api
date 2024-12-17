using AutoMapper;
using Product.Api.Dtos.Reponses;
using Product.Api.Dtos.Requests;

namespace Product.Api.Mappings.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Models.Category, CategoryRequest>().ReverseMap();
            CreateMap<Models.Category, CategoryRequest.ChildrenRequest>().ReverseMap();
            CreateMap<Models.Category, CategoryRequest.ProductRequest>().ReverseMap();
            CreateMap<Models.Category, CategoryReponse>().ReverseMap();
            CreateMap<Models.Category, CategoryReponse.Child>().ReverseMap();
            CreateMap<Models.Category, CategoryReponse.Product>().ReverseMap();

        }
    }
}
