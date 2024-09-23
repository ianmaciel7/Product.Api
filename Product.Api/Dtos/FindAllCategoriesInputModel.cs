

using Microsoft.AspNetCore.Mvc;

namespace Product.Api.Dtos
{
    public record FindAllCategoriesInputModel([FromQuery]int? CategoryId) : IFindCategoriesInputModel
    {
    }
}
