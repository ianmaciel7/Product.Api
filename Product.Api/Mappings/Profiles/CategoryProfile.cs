using AutoMapper;
using Product.Api.Data.Entities;
using Product.Api.Dtos;
using Product.Api.Dtos.Base;
using Product.Api.Services;

namespace Product.Api.Mappings.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, FindCategoryOutputModel>()
                .ForCtorParam("CategoryId", opt => opt.MapFrom(src => src.CategoryId))
                .ForCtorParam("Name", opt => opt.MapFrom(src => src.Name))
                .ForCtorParam("Products", opt => opt.MapFrom(src => src.Products))
                .ForCtorParam("Children", opt => opt.MapFrom(src => src.Children))
                .ForCtorParam("Parent", opt => opt.MapFrom((src, context) => context.Mapper.Map<IFindCategoryOutputModel>(src.Parent)));
            CreateMap<Category, IFindCategoryOutputModel>().As<FindCategoryOutputModel>();
            CreateMap<AddCategoryInputModel, Category>();

            CreateMap<IEnumerable<Category>, FindAllCategoriesOutputModel>()
                .ForCtorParam("Categories", opt => opt.MapFrom((src,cotext) => cotext.Mapper.Map<IEnumerable<FindCategoryOutputModel>>(src)));

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
