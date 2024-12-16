using Product.Api.Models.ValueObjects;

namespace Product.Api.Dtos
{
    public record CategoryDto(
        string Name = "",
        string Description = "",
        IEnumerable<ProductDto> Products = null!,
        IEnumerable<CategoryDto> Children = null!,
        CategoryId? ParentId = null
    )
    {
    }
}
