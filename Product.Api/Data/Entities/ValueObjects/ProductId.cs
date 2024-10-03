using Microsoft.EntityFrameworkCore;

namespace Product.Api.Data.Entities.ValueObjects
{
    [Owned]
    public record ProductId(int Value) : IEqualityComparer<ProductId>, IPrimaryKey<int>
    {
        object IPrimaryKey.Value => Value;

        public override string ToString() => Value.ToString();
        public static implicit operator int(ProductId id) => id.Value;
        public static implicit operator int?(ProductId? id) => id?.Value ?? default;
        public static implicit operator ProductId(int value) => new(value);
        public bool Equals(ProductId x, ProductId y) => x.Value == y.Value;
        public int GetHashCode(ProductId obj) => obj;
    }
}
