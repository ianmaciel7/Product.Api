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

            CreateMap<Entities.Product, FindProductOutputModel>();
            CreateMap<IEnumerable<Entities.Product>, FindAllProductsOutputModel>()
                .ConvertUsing((src, dest, context) =>
                {
                    var p = context.Mapper.Map<IEnumerable<IFindProductOutputModel>>(src);
                    return new FindAllProductsOutputModel(p);
                });
            CreateMap<Entities.Product, IFindProductOutputModel>().As<FindProductOutputModel>();
            CreateMap<Entities.Product, IAddProductOutputModel>().As<FindProductOutputModel>();
            CreateMap<Entities.Product, IUpdateProductOutputModel>().As<FindProductOutputModel>();
            CreateMap<Entities.Product, IRemoveProductOutputModel>().As<FindProductOutputModel>();
            CreateMap<Entities.Product, Uri?>().ConstructUsing(MapByUri);
            CreateMap<IEnumerable<Entities.Product>, IFindAllProductsOutputModel>().As<FindAllProductsOutputModel>();

            CreateMap<IAddProductInputModel, Entities.Product>();
            CreateMap<IUpdateProductInputModel, Entities.Product>();
        }

        private Uri? MapByUri(Entities.Product product,ResolutionContext context)
        {
            var urlService = context.Items["urlService"] as IUrlService;
            var uri = urlService?.GetProductUri(new(product.ProductId));
            return uri;
        }
    }
}
