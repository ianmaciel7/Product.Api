using AutoMapper;
using Product.Api.Data.Entities;
using Product.Api.Dtos;
using Product.Api.Services;

namespace Product.Api.Mappings.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, FindAllCategoriesInputModel>();
            CreateMap<Category, FindAllCategoriesOutputModel>();
            CreateMap<Category, FindCategoryOutputModel>()
                .ForCtorParam("CategoryId", opt => opt.MapFrom(src => src.CategoryId))
                .ForCtorParam("Name", opt => opt.MapFrom(src => src.Name))
                .ForCtorParam("Products", opt => opt.MapFrom(src => src.Products))
                .ForCtorParam("SubCategories", opt => opt.MapFrom(src => src.SubCategories))
                .ForCtorParam("Parent", opt => opt.MapFrom((src,context) => MapByUri(src.Parent, context)));
            CreateMap<IEnumerable<Category>, FindAllCategoriesOutputModel>().ForCtorParam("Categories", opt => opt.MapFrom(src => src));
            CreateMap<Category, Uri?>().ConstructUsing(MapByUri);    
        }

        private Uri? MapByUri(Category? category, ResolutionContext context)
        {
            if(category == null)
            {
                return null;
            }
            var urlService = context.Items["urlService"] as IUrlService;
            var uri = urlService?.GetCategoryUri(new(category.CategoryId));
            return uri;
        }
    }
}
