using Product.Api.Services;

namespace Product.Api.Extensions
{
    public static class AddServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
