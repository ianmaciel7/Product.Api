using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record AddProductInputModel(string Name, decimal Price, string Description, int CategoryId) : IAddProductInputModel
    {
    }
}
