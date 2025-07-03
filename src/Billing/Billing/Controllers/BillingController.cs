using Billing.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Billing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IExternalBillingService _externalBillingService;
        public BillingController(IExternalBillingService externalBillingService)
        {
            _externalBillingService = externalBillingService ?? throw new ArgumentNullException(nameof(externalBillingService));
        }
        [HttpGet]
        public async Task<IActionResult> GetBillingsAsync()
        {
            var billings = await _externalBillingService.GetBillingsAsync();
            return Ok(billings);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetBillingsByIdAsync(Guid id)
        {
            var billings = await _externalBillingService.GetBillingsByIdAsync(id);
            return Ok(billings);
        }
    }
}
