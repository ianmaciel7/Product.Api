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
            CreateMap<IEnumerable<Category>, FindAllCategoriesOutputModel>()
               .ConvertUsing((src, dest, context) =>
               {
                   var p = context.Mapper.Map<IEnumerable<IFindCategoryOutputModel>>(src);
                   return new FindAllCategoriesOutputModel(p);
               });
            CreateMap<Category, FindCategoryOutputModel>();
            CreateMap<Category, IFindCategoryOutputModel>().As<FindCategoryOutputModel>();
            CreateMap<Category, IAddCategoryOutputModel>().As<FindCategoryOutputModel>();
            CreateMap<Category, IUpdateCategoryOutputModel>().As<FindCategoryOutputModel>();
            CreateMap<Category, IRemoveCategoryOuputModel>().As<FindCategoryOutputModel>();
            CreateMap<Category, Uri?>().ConstructUsing(MapByUri);
            CreateMap<IEnumerable<Category>, IFindAllCategoriesOutputModel>().As<FindAllCategoriesOutputModel>();
            CreateMap<AddCategoryInputModel, Category>();
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
