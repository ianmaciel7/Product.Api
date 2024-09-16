
using Microsoft.AspNetCore.Mvc;
using Product.Api.Dtos;
using Product.Api.Services;

namespace Product.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]   
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet(Name = GET_CATEGORIES)]
        public IActionResult Get([FromQuery] GetCategoriesInputModel inputModel)
        {
            var categories = categoryService.Get(inputModel);
            return Ok(categories);
        }
    }
}
