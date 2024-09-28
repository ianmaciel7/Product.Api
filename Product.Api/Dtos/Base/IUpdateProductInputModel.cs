using Product.Api.Data.Entities.ValueObjects;

namespace Product.Api.Dtos.Base
{
    public interface IUpdateProductInputModel : IAddProductInputModel
    {
        ProductId? ProductId { get; }
    }
}