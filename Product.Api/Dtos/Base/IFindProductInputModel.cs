using Product.Api.Data.Entities.ValueObjects;

namespace Product.Api.Dtos.Base
{
    public interface IFindProductInputModel : IProductInputModel
    {
        ProductId ProductId { get; }
    }
}