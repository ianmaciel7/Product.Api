using Microsoft.AspNetCore.Mvc;
using Product.Api.Data.Entities.ValueObjects;
using Product.Api.Dtos;
using Product.Api.Services;

namespace Product.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet(Name = GET_ALL_PRODUCTS)]
        public IActionResult Get(FindAllProductsInputModel inputModel)
        {
            var products = productService.FindAll(inputModel);
            return Ok(products);
        }

        [HttpGet("{ProductId:int}", Name = GET_PRODUCT)]
        public IActionResult Get(FindProductInputModel inputModel)
        {
            var products = productService.Find(inputModel);
            return Ok(products);
        }

        [HttpPost(Name = POST_PRODUCT)]
        public IActionResult Post([FromBody] AddProductInputModel inputModel)
        {
            var products = productService.Add(inputModel);
            return Ok(products);
        }

        [HttpDelete("{ProductId:int}", Name = DELETE_PRODUCT)]
        public IActionResult Delete(RemoveProductInputModel inputModel)
        {
            var categories = productService.Remove(inputModel);
            return Ok(categories);
        }

        [HttpPut(Name = PUT_PRODUCT)]
        public IActionResult Put([FromBody] UpdateProductInputModel inputModel)
        {
            var categories = productService.Update(inputModel);
            return Ok(categories);
        }


        [HttpPut("{ProductId:int}", Name = PUT_EXIST_PRODUCT)]
        public IActionResult Put(
            [FromRoute] ProductId ProductId, 
            [FromBody] UpdateProductInputModel inputModel
        )
        {
            inputModel = inputModel with { ProductId = ProductId };
            var categories = productService.Update(inputModel);
            return Ok(categories);
        }
    }
}
