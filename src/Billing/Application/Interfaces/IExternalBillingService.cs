using Billing.Application.DTO;

namespace Billing.Application.Interfaces
{
    public interface IExternalBillingService
    {
        Task<IEnumerable<BillingDTO>> GetBillingsAsync();
        Task<BillingDTO> GetBillingsByIdAsync(int id);
        Task<bool> AddBillingAsync(int id);
    }
}
