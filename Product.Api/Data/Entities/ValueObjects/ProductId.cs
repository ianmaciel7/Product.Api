using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Product.Api.Data.Entities.ValueObjects
{
    [Owned]
    public record ProductId(int Value) : IParsable<ProductId>, IEqualityComparer<ProductId>
    {
        public static ProductId Parse(string s, IFormatProvider? provider)
        {
            return new ProductId(int.Parse(s, provider));
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out ProductId result)
        {
            if (int.TryParse(s, NumberStyles.Integer, provider, out var value))
            {
                result = new ProductId(value);
                return true;
            }

            result = new ProductId(default(int));
            return false;
        }

        public override string ToString() => Value.ToString();
        public static implicit operator int(ProductId id) => id.Value;
        public static implicit operator int?(ProductId? id) => id?.Value ?? default;
        public static implicit operator ProductId(int value) => new(value);
        public bool Equals(ProductId x, ProductId y) => x.Value == y.Value;
        public int GetHashCode(ProductId obj) => obj;
    }
}
