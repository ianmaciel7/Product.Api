using AutoMapper;

namespace Product.Api.Mappings.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Models.Category, Dtos.CategoryDto>();
            CreateMap<Dtos.CategoryDto, Models.Category>();
        }
    }
}
