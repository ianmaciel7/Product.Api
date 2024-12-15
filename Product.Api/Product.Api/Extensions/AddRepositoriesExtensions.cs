using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Product.Api.Data;
using Product.Api.Models.ValueObjects;
using Product.Api.Options;
using Product.Api.Repositories;

namespace Product.Api.Extensions
{
    public static class AddRepositoriesExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            var featureFlagsOptions = services.BuildServiceProvider().GetRequiredService<IOptions<FeatureFlagsOptions>>().Value;
            var connectionString = services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection");
            var dbname = new SqlConnectionStringBuilder(connectionString).InitialCatalog;

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                if (featureFlagsOptions.UseSqlServer)
                {
                    options.UseSqlServer(connectionString);
                    return;
                }
                options.UseInMemoryDatabase(dbname);
            });
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IGenericRepository<Models.Product, ProductId>, Repository<Models.Product, ProductId>>();
            services.AddScoped<IGenericRepository<Models.Category, CategoryId>, Repository<Models.Category, CategoryId>>();
        }
    }
}
