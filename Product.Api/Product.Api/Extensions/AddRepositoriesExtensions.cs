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
            

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                if (featureFlagsOptions.UseSqlServer)
                {
                    options.UseSqlServer(connectionString);
                    return;
                }
                if (featureFlagsOptions.UseInMemoryDatabase)
                {
                    var sqlConnection = new SqlConnectionStringBuilder(connectionString);
                    var dbname = sqlConnection.InitialCatalog;
                    options.UseInMemoryDatabase(dbname);
                    return;
                }
                throw new InvalidOperationException("No database provider was configured.");
            });
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepostiory, CategoryRepostiory>();

            services.AddScoped<IGenericRepository<Models.Product, ProductId>, GenericRepository<Models.Product, ProductId>>();
            services.AddScoped<IGenericRepository<Models.Category, CategoryId>, GenericRepository<Models.Category, CategoryId>>();
        }
    }
}
