using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Product.Api.Data.Entities.ValueObjects
{
    [Owned]
    public record CategoryId(int Value) : IParsable<CategoryId>,IEqualityComparer<CategoryId>
    {
        public static CategoryId Parse(string s, IFormatProvider? provider)
        {
            return new CategoryId(int.Parse(s, provider));
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out CategoryId result)
        {
            if (int.TryParse(s, NumberStyles.Integer, provider, out var value))
            {
                result = new CategoryId(value);
                return true;
            }

            result = new CategoryId(default(int));
            return false;
        }

        public override string ToString() => Value.ToString();
        public static implicit operator int(CategoryId id) => id.Value;
        public static implicit operator int?(CategoryId? id) => id?.Value ?? default;
        public static implicit operator CategoryId(int value) => new(value);

        public bool Equals(CategoryId x, CategoryId y) => x.Value == y.Value;
        public int GetHashCode(CategoryId obj) => obj;

        internal static CategoryId Parse(int? value)
        {
            if (value.HasValue)
            {
                return new CategoryId(value.Value);
            }
            return new CategoryId(default(int));
        }
    }
}
