
using Microsoft.AspNetCore.Mvc;
using Product.Api.Data.Entities.ValueObjects;
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

        [HttpDelete("{CategoryId:int}", Name = DELETE_CATEGORY)]
        public IActionResult Delete(RemoveCategoryInputModel inputModel)
        {
            var categories = categoryService.Remove(inputModel);
            return Ok(categories);
        }

        [HttpPut(Name = PUT_CATEGORY)]
        public IActionResult Put([FromBody] UpdateCategoryInputModel inputModel)
        {
            var categories = categoryService.Update(inputModel);
            return Ok(categories);
        }

        [HttpPut("{CategoryId:int}", Name = PUT_EXIST_CATEGORY)]
        public IActionResult Put(
            [FromRoute] CategoryId CategoryId,
            [FromBody] UpdateCategoryInputModel inputModel
        )
        {
            inputModel = inputModel with { CategoryId = CategoryId };
            var categories = categoryService.Update(inputModel);
            return Ok(categories);
        }
    }
}
