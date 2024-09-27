using AutoMapper;
using Product.Api.Dtos;
using Product.Api.Dtos.Base;
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
               .ForCtorParam("Category", opt => opt.MapFrom((src,context) => context.Mapper.Map<IFindCategoryOutputModel>(src.Category)))
               .ForCtorParam("Price", opt => opt.MapFrom(src => src.Price));
            CreateMap<IEnumerable<Entities.Product>, FindAllProductsOutputModel>()
                .ForCtorParam("Products", opt => opt.MapFrom((src, context) => context.Mapper.Map<IEnumerable<FindProductOutputModel>>(src)));

            CreateMap<Entities.Product, IFindProductOutputModel>().As<FindProductOutputModel>();
            CreateMap<Entities.Product, IAddProductOutputModel>().As<FindProductOutputModel>();
            CreateMap<Entities.Product, IUpdateProductOutputModel>().As<FindProductOutputModel>();
            CreateMap<Entities.Product, IRemoveProductOutputModel>().As<FindProductOutputModel>();
            CreateMap<Entities.Product, Uri?>().ConstructUsing(MapByUri);
            CreateMap<IEnumerable<Entities.Product>, IFindAllProductsOutputModel>().As<FindAllProductsOutputModel>();

            CreateMap<AddProductInputModel, Entities.Product>();
            CreateMap<UpdateProductInputModel, Entities.Product>();


           

            

        }

        private Uri? MapByUri(Entities.Product product,ResolutionContext context)
        {
            var urlService = context.Items["urlService"] as IUrlService;
            var uri = urlService?.GetProductUri(new(product.ProductId));
            return uri;
        }
    }
}
