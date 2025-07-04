using AutoMapper;
using Billing.Application.DTO;
using Billing.Application.Interfaces;
using Billing.Application.Interfaces.InfraInterfaces;
using Billing.Domain.Interfaces;


namespace Billing.Application.Services
{
    public class ExternalBillingService : IExternalBillingService
    {
        private readonly IExternalBillingClient _externalBilling;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBillingRepository _billingRepository;
        public ExternalBillingService(
            IExternalBillingClient externalBilling,
            IMapper mapper,
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IBillingRepository billingRepository
            )
        {
            _externalBilling = externalBilling ?? throw new ArgumentNullException(nameof(externalBilling));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _billingRepository = billingRepository ?? throw new ArgumentNullException(nameof(billingRepository));
        }
        public  async Task<IEnumerable<BillingDTO>> GetBillingsAsync()
        {
            return await _externalBilling.GetBillingsAsync();
        }

        public async Task<BillingDTO> GetBillingsByIdAsync(int id)
        {
           return await  _externalBilling.GetBillingsByIdAsync(id);
        }
        public async Task<bool> AddBillingAsync(int id)
        {
            var billing = await _externalBilling.GetBillingsByIdAsync(id);
            if (billing == null)
            {
                throw new ArgumentNullException(nameof(billing), "Billing not found");
            }
            if(billing.Customer == null)
                throw new ArgumentNullException(nameof(billing.Customer), "Customer not found");
            if(billing.BillingLines?.FirstOrDefault()?.ProductId.ToString() == null)
                throw new ArgumentNullException("Product not found");

            var newBilling =  _mapper.Map<Domain.Entities.Billing>(billing);
            await _billingRepository.AddBillingAsync(newBilling).ConfigureAwait(false);
            return true;
        }
    }
}
