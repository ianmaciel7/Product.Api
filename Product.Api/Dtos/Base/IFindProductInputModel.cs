namespace Product.Api.Dtos.Base
{
    public interface IFindProductInputModel : IProductInputModel
    {
        int ProductId { get; }
    }
}