namespace Product.Api.Models.ValueObjects
{
    public record CategoryId(Guid Value) : IPrimaryKey
    {
    }
}
