using Microsoft.AspNetCore.Mvc;
using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record FindCategoryInputModel([FromRoute]int CategoryId) : IFindCategoryInputModel
    {
       
    }
}
