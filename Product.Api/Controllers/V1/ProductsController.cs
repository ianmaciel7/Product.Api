using Microsoft.AspNetCore.Mvc;
using Product.Api.Dtos;
using Product.Api.Services;

namespace Product.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet(Name = GET_PRODUCTS)]
        public IActionResult Get([FromQuery] GetProductsInputModel inputModel)
        {
            var products = productService.Get(inputModel);
            return Ok(products);
        }
    }
}
