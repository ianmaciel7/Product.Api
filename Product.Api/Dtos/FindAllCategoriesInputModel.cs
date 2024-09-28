

using Microsoft.AspNetCore.Mvc;
using Product.Api.Data.Entities.ValueObjects;

namespace Product.Api.Dtos
{
    public record FindAllCategoriesInputModel([FromQuery]CategoryId? CategoryId) : IFindAllCategoriesInputModel
    {
    }
}
