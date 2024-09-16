using AutoMapper;
using Product.Api.Dtos;
using Product.Api.Services;

namespace Product.Api.Mappings.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Entities.Product, GetProductsInputModel>();
            CreateMap<Entities.Product, CompactProcuctOutputModel>()
               .ForCtorParam("ProductId", opt => opt.MapFrom(src => src.ProductId))
               .ForCtorParam("Name", opt => opt.MapFrom(src => src.Name))
               .ForCtorParam("Description", opt => opt.MapFrom(src => src.Description))
               .ForCtorParam("Category", opt => opt.MapFrom(src => src.Category))
               .ForCtorParam("Price", opt => opt.MapFrom(src => src.Price));
            CreateMap<IEnumerable<Entities.Product>, GetProductsOutputModel>()
                .ForCtorParam("Products", opt => opt.MapFrom((src, context) => context.Mapper.Map<IEnumerable<CompactProcuctOutputModel>>(src)));
            CreateMap<Entities.Product, Uri>()
                .ConstructUsing(MapByUri);

        }

        private Uri MapByUri(Entities.Product product,ResolutionContext context)
        {
            var urlService = context.Items["urlService"] as IUrlService;
            var uri = urlService?.GetProducts(product.ProductId);
            return uri;
        }
    }
}
