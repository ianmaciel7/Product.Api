using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record RemoveProductInputModel(int ProductId) : IRemoveProductInputModel;
}
