using Microsoft.EntityFrameworkCore;

namespace Product.Api.Data.Entities.ValueObjects
{
    [Owned]
    public record CategoryId(int Value) : IEqualityComparer<CategoryId>, IPrimaryKey<int>
    {
        object IPrimaryKey.Value => Value;

        public override string ToString() => Value.ToString();
        public static implicit operator int(CategoryId id) => id.Value;
        public static implicit operator int?(CategoryId? id) => id?.Value ?? default;
        public static implicit operator CategoryId(int value) => new(value);

        public bool Equals(CategoryId x, CategoryId y) => x.Value == y.Value;
        public int GetHashCode(CategoryId obj) => obj;
    }
}
