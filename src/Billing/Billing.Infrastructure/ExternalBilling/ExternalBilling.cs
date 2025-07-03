using Billing.Application.DTO;
using Billing.Application.Interfaces.InfraInterfaces;
using Billing.Domain.Interfaces;
using System.Net.Http.Json;

namespace Billing.Infrastructure.ExternalBilling
{
    public class ExternalBilling : IExternalBillingClient
    {
        private readonly HttpClient _httpClient;
        public ExternalBilling(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<List<BillingDTO>> GetBillingsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<BillingDTO>>("https://65c3b12439055e7482c16bca.mockapi.io/api/v1/billing");
            return response ?? new List<BillingDTO>();
        }

        public async Task<BillingDTO> GetBillingsByIdAsync(Guid id) 
        {
            var response = await _httpClient.GetFromJsonAsync<BillingDTO>($"https://65c3b12439055e7482c16bca.mockapi.io/api/v1/billing/{id}");
            return response ?? new BillingDTO();
        }
    }
}
