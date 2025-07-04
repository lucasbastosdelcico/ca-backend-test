using Billing.Application.Interfaces;
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
        [Route("sync")]
        public async Task<IActionResult> GetBillingsAsync()
        {
            var billings = await _externalBillingService.GetBillingsAsync().ConfigureAwait(false);
            return Ok(billings);
        }

        [HttpGet]
        [Route("sync/{id:int}")]
        public async Task<IActionResult> GetBillingsByIdAsync(int id)
        {
            var billings = await _externalBillingService.GetBillingsByIdAsync(id).ConfigureAwait(false);
            return Ok(billings);
        }
        [HttpPost]
        [Route("sync{id:int}")]
        public async Task<IActionResult> AddBillingAsync(int id)
        {
            var result = await _externalBillingService.AddBillingAsync(id).ConfigureAwait(false);  
            return Created();
        }
    }
}
