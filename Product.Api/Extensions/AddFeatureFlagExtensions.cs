using Product.Api.Options;

namespace Product.Api.Extensions
{
    public static class AddFeatureFlagExtensions
    {
        public static void AddFeatureFlag(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.Configure<FeatureFlagsOptions>(configuration.GetSection("FeatureFlags"));
        }
    }
}
