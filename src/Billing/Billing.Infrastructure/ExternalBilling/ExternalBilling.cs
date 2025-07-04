using Billing.Application.DTO;
using Billing.Application.Interfaces.InfraInterfaces;
using Billing.Domain.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace Billing.Infrastructure.ExternalBilling
{
    public class ExternalBilling : IExternalBillingClient
    {
        private readonly HttpClient _httpClient;
        public ExternalBilling(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<IEnumerable<BillingDTO>> GetBillingsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<BillingDTO>>("https://65c3b12439055e7482c16bca.mockapi.io/api/v1/billing");
            return response ?? new List<BillingDTO>();
        }

        public async Task<BillingDTO> GetBillingsByIdAsync(int id)
        {
            var response = await _httpClient.GetStringAsync($"https://65c3b12439055e7482c16bca.mockapi.io/api/v1/billing/{id}");

            using var document = JsonDocument.Parse(response);
            var root = document.RootElement;

            if (root.TryGetProperty("0", out JsonElement nested))
            {
                var dto = JsonSerializer.Deserialize<BillingDTO>(nested.GetRawText(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return dto ?? new BillingDTO();
            }
            return new BillingDTO();
        }

    }
}
