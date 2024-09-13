using AutoMapper;
using Product.Api.Data.Entities.Categories;
using Product.Api.Dtos;

namespace Product.Api.Mappings.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, GetCategoryInputModel>();
            CreateMap<IEnumerable<Category>, GetCategoryOutputModel>().ConstructUsing(categories => new GetCategoryOutputModel(categories));

        }
    }
}
