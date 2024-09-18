using Microsoft.AspNetCore.Mvc;

namespace Product.Api.Dtos
{
    public record FindCategoryInputModel([FromRoute]int CategoryId) : IFindCategoriesInputModel
    {
        int? IFindCategoriesInputModel.CategoryId => CategoryId;
    }
}
