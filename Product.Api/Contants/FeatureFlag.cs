using Product.Api.Managements;

namespace Product.Api.Contants
{
    public record DatabaseProviderFeature
    {
        public string SqlServer => nameof(DatabaseProviderType.SqlServer);
        public string InMemory => nameof(DatabaseProviderType.InMemory);

    }


    public static class FeatureFlag
    {
        public static DatabaseProviderFeature DatabaseProvider => new DatabaseProviderFeature();
    }
}
