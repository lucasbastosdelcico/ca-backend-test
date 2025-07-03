using Application.DTO.Command;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Billing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices ?? throw new ArgumentNullException(nameof(productServices)); ;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _productServices.GetAllAsync().ConfigureAwait(false);
            if (!result.Any())
                return NoContent();
            return Ok(result);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (id <= 0) return BadRequest("ID must be greater than zero.");
            var result = await _productServices.GetByIdAsync(id).ConfigureAwait(false);
            if (result == null) return NotFound($"Product with ID {id} not found.");
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ProductCommand product)
        {
            if (product == null) return BadRequest("Product cannot be null.");
            await _productServices.AddAsync(product).ConfigureAwait(false);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ProductCommand product)
        {
            if (int.Parse(product.Id) <= 0) return BadRequest("ID must be greater than zero.");
            if (product == null) return BadRequest("Product cannot be null.");
            await _productServices.UpdateAsync(product).ConfigureAwait(false);
            return NoContent();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id <= 0) return BadRequest("ID must be greater than zero.");
            await _productServices.DeleteAsync(id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
