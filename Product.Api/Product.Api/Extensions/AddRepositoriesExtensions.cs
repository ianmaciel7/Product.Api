using Product.Api.Repositories;

namespace Product.Api.Extensions
{
    public static class AddRepositoriesExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
