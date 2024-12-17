using AutoMapper;
using Product.Api.Dtos.Reponses;
using Product.Api.Dtos.Requests;

namespace Product.Api.Mappings.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Models.Product, ProductRequest>().ReverseMap();
            CreateMap<Models.Product, ProductRequest.CategoryRequest>().ReverseMap();
            CreateMap<Models.Product, ProductRequest.ProductPreviewRequest>().ReverseMap();

            CreateMap<Models.Product, ProductReponse>().ReverseMap();
            CreateMap<Models.Product, ProductReponse.CategoryResponse>().ReverseMap();
            CreateMap<Models.Product, ProductReponse.ProductResponse>().ReverseMap();
        }
    }
}
