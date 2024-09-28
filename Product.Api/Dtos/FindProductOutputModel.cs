using Product.Api.Data.Entities.ValueObjects;
using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record FindProductOutputModel(
        ProductId ProductId,
        string Name,
        decimal Price, 
        string Description, 
        CategoryId? CategoryId,
        string? CategoryName
    ) : IFindProductOutputModel, 
        IAddProductOutputModel, 
        IUpdateProductOutputModel, 
        IRemoveProductOutputModel
    {

    }
}
