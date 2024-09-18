using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record FindProductOutputModel(int ProductId, string Name, string Description, decimal Price, Uri Category) : IOutputModel<Entities.Product>
    {

    }
}
