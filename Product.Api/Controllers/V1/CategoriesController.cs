
using Microsoft.AspNetCore.Mvc;
using Product.Api.Dtos;
using Product.Api.Services;

namespace Product.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]   
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet(Name = GET_ALL_CATEGORIES)]
        public IActionResult Get(FindAllCategoriesInputModel inputModel)
        {
            var categories = categoryService.FindAll(inputModel);
            return Ok(categories);
        }

        [HttpGet("{CategoryId:int}", Name = GET_CATEGORY)]
        public IActionResult Get(FindCategoryInputModel inputModel)
        {
            var categories = categoryService.Find(inputModel);
            return Ok(categories);
        }

        [HttpPost(Name = POST_CATEGORY)]
        public IActionResult Post([FromBody] AddCategoryInputModel inputModel)
        {
            var categories = categoryService.Add(inputModel);
            return Ok(categories);
        }
    }
}
