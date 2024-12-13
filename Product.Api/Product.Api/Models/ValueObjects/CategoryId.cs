using System.Diagnostics.CodeAnalysis;

namespace Product.Api.Models.ValueObjects
{
    public record CategoryId(Guid Value) : IKey, IParsable<CategoryId>
    {
        public static CategoryId Parse(string s, IFormatProvider? provider)
        {
            return new CategoryId(Guid.Parse(s));
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out CategoryId result)
        {
            if (Guid.TryParse(s, out var guid))
            {
                result = new CategoryId(guid);
                return true;
            }
            result = null!;
            return false;
        }
    }
}
