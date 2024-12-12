namespace Product.Api.Models.ValueObjects
{
    public record ProductId(Guid Value) : IPrimaryKey
    {
    }
}
