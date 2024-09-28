using Microsoft.AspNetCore.Mvc;
using Product.Api.Data.Entities.ValueObjects;
using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record FindCategoryInputModel([FromRoute]CategoryId CategoryId) : IFindCategoryInputModel
    {
       
    }
}
