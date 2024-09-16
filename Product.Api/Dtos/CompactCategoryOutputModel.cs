using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record CompactCategoryOutputModel(int CategoryId, string Name, IEnumerable<Uri> Products) : IOutputModel<Entities.Product>;
}
