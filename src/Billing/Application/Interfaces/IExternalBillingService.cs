using Billing.Application.DTO;

namespace Billing.Application.Interfaces
{
    public interface IExternalBillingService
    {
        Task<List<BillingDTO>> GetBillingsAsync();
        Task<BillingDTO> GetBillingsByIdAsync(Guid id);
        
    }
}
