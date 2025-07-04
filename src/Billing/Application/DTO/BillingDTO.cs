using Application.DTO.Command;
using Billing.Domain.Entities;
using System.Text.Json.Serialization;

namespace Billing.Application.DTO
{
    public class BillingDTO
    {
        [JsonPropertyName("invoice_number")]
        public string? InvoiceNumber { get; set; }

        [JsonPropertyName("customer")]
        public CustomerCommand? Customer { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("due_date")]
        public DateTime DueDate { get; set; }

        [JsonPropertyName("total_amount")]
        public decimal TotalAmount { get; set; }

        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("lines")]
        public List<BillingLineDTO>? BillingLines { get; set; }
    }
}
