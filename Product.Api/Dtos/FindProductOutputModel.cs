using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record FindProductOutputModel(
        int ProductId,
        string Name,
        decimal Price, 
        string Description, 
        IFindCategoryOutputModel? Category
    ) : IFindProductOutputModel, 
        IAddProductOutputModel, 
        IUpdateProductOutputModel, 
        IRemoveProductOutputModel
    {

    }
}
