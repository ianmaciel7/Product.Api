using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record FindCategoryOutputModel(int CategoryId, string Name, IEnumerable<Uri> SubCategories, IEnumerable<Uri> Products,Uri Parent) : IOutputModel<Entities.Product>;
}
