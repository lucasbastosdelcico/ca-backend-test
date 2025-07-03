using Application.DTO.Command;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Billing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices ?? throw new ArgumentNullException(nameof(customerServices));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _customerServices.GetAllAsync().ConfigureAwait(false);
            if (!result.Any())
                return NoContent();

            return Ok(result);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (id <= 0) return BadRequest("ID must be greater than zero.");
            var result = await _customerServices.GetByIdAsync(id).ConfigureAwait(false);
            if (result == null) return NotFound($"Customer with ID {id} not found.");
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CustomerCommand customer)
        {
            if (customer == null) return BadRequest("Customer cannot be null.");
            await _customerServices.AddAsync(customer).ConfigureAwait(false);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomerCommand customer)
        {
            if (int.Parse(customer.Id) <= 0) return BadRequest("ID must be greater than zero.");
            if (customer == null) return BadRequest("Customer cannot be null.");
            await _customerServices.UpdateAsync(customer).ConfigureAwait(false);
            return NoContent();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id <= 0) return BadRequest("ID must be greater than zero.");
            await _customerServices.DeleteAsync(id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
