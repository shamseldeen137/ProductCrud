
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
namespace ProductCrud.Web.Controllers
{
  
        [ApiController]
        [Route("api/[controller]")]
        public class ProductsController : ControllerBase
        {
            private readonly IProductService _productAppService;

            public ProductsController(IProductService productAppService)
            {
                _productAppService = productAppService;
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetProduct(int id)
            {
                try
                {
                    var product = await _productAppService.GetProduct(id);
                    return Ok(product);
                }
                catch (BusinessException ex) when (ex.Code == "404")
                {
                    return NotFound(new { Message = ex.Message, ProductId = ex.Data["ProductId"] });
                }
            }

            [HttpPost]
            public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto input)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdProduct = await _productAppService.CreateAsync(input);
                return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto input)
            {
                if (id != input.Id)
                {
                    return BadRequest(new { Message = "Product ID mismatch" });
                }

                try
                {
                    var updatedProduct = await _productAppService.Update( input);
                if (updatedProduct == null) {
                    return NotFound( );

                }
                return Ok(updatedProduct);
                }
                catch (BusinessException ex) when (ex.Code == "ProductNotFound")
                {
                    return NotFound(new { Message = ex.Message, ProductId = ex.Data["ProductId"] });
                }
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteProduct(int id)
            {
                try
                {
                    await _productAppService.DeleteAsync(id);
                    return NoContent();
                }
                catch (BusinessException ex) when (ex.Code == "404")
                {
                    return NotFound(new { Message = ex.Message, ProductId = ex.Data["ProductId"] });
                }
            }
        }
    }


