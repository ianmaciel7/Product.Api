namespace Product.Api.Dtos.Base
{
    public interface IUpdateProductInputModel : IAddProductInputModel
    {
        int? ProductId { get; }
    }
}