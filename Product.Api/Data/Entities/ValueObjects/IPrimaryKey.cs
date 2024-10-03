namespace Product.Api.Data.Entities.ValueObjects
{
    public interface IPrimaryKey<T> : IPrimaryKey
    {
        new T Value { get; }
    }

    public interface IPrimaryKey
    {
        object Value { get; }
    }
}