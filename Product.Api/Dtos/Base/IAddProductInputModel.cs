namespace Product.Api.Dtos.Base
{
    public interface IAddProductInputModel : IProductInputModel
    {
        string Name { get; }
        decimal Price { get; }
        string Description { get; }
        int CategoryId { get; }
    }
}
