using AutoMapper;
using Billing.Application.DTO;
using Billing.Application.Interfaces;
using Billing.Application.Interfaces.InfraInterfaces;


namespace Billing.Application.Services
{
    public class ExternalBillingService : IExternalBillingService
    {
        private readonly IExternalBillingClient _externalBilling;
        private readonly IMapper _mapper;
        public ExternalBillingService(
            IExternalBillingClient externalBilling,
            IMapper mapper
            )
        {
            _externalBilling = externalBilling ?? throw new ArgumentNullException(nameof(externalBilling));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public  async Task<List<BillingDTO>> GetBillingsAsync()
        {
            return await _externalBilling.GetBillingsAsync();
        }

        public async Task<BillingDTO> GetBillingsByIdAsync(Guid id)
        {
           return await  _externalBilling.GetBillingsByIdAsync(id);
        }
    }
}
