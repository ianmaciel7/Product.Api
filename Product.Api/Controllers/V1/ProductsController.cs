using Microsoft.AspNetCore.Mvc;
using Product.Api.Dtos;
using Product.Api.Services;

namespace Product.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] GetProductInputModel inputModel)
        {
            var categories = productService.Get(inputModel);
            return Ok(categories);
        }
    }
}
