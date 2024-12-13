using System.Diagnostics.CodeAnalysis;

namespace Product.Api.Models.ValueObjects
{
    public record ProductId(Guid Value) : IKey, IParsable<ProductId>
    {
        public static ProductId Parse(string s, IFormatProvider? provider)
        {
            return new ProductId(Guid.Parse(s));
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out ProductId result)
        {
            if (Guid.TryParse(s, out var guid))
            {
                result = new ProductId(guid);
                return true;
            }
            result = null!;
            return false;
        }
    }
}
