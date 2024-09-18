

using Microsoft.AspNetCore.Mvc;

namespace Product.Api.Dtos
{
    public record FindAllCategoriesInputModel([FromRoute]int? CategoryId) : IFindCategoriesInputModel
    {
    }
}
