using AutoMapper;
using Product.Api.Dtos;
using Product.Api.Services;

namespace Product.Api.Mappings.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Entities.Product, FindProductOutputModel>()
               .ForCtorParam("ProductId", opt => opt.MapFrom(src => src.ProductId))
               .ForCtorParam("Name", opt => opt.MapFrom(src => src.Name))
               .ForCtorParam("Description", opt => opt.MapFrom(src => src.Description))
               .ForCtorParam("Category", opt => opt.MapFrom((src,context) => context.Mapper.Map<FindCategoryOutputModel>(src.Category)))
               .ForCtorParam("Price", opt => opt.MapFrom(src => src.Price));
            CreateMap<AddProductInputModel, Entities.Product>();
            CreateMap<UpdateProductInputModel, Entities.Product>();

            CreateMap<IEnumerable<Entities.Product>, FindAllProductsOutputModel>()
                .ForCtorParam("Products", opt => opt.MapFrom((src, context) => context.Mapper.Map<IEnumerable<FindProductOutputModel>>(src)));
            CreateMap<Entities.Product, Uri?>()
                .ConstructUsing(MapByUri);

        }

        private Uri? MapByUri(Entities.Product product,ResolutionContext context)
        {
            var urlService = context.Items["urlService"] as IUrlService;
            var uri = urlService?.GetProductUri(new(product.ProductId));
            return uri;
        }
    }
}
