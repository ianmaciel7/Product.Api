using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record FindProductInputModel(int ProductId) : IFindProductInputModel
    {
    }
}
