using AutoMapper;
using Product.Api.Services;

namespace Product.Api.Mappings.Extensions
{
    public static class MapExtensions
    {
        public static TDestination Map<TDestination>(
           this IMapper mapper,
           object source,
           IUrlService urlService)
        {
            return mapper.Map<TDestination>(source, options =>
            {
                options.Items["urlService"] = urlService;
            });
        }
    }
}
