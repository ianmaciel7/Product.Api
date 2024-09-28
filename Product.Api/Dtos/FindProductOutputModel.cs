using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record FindProductOutputModel(
        int ProductId,
        string Name,
        decimal Price, 
        string Description, 
        int? CategoryId,
        string? CategoryName
    ) : IFindProductOutputModel, 
        IAddProductOutputModel, 
        IUpdateProductOutputModel, 
        IRemoveProductOutputModel
    {

    }
}
