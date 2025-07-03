using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Billing.Application.DTO
{
    public class BillingLineDTO
    {
        
        
            [JsonPropertyName("productId")]
            public Guid ProductId { get; set; }

            [JsonPropertyName("description")]
            public string? Description { get; set; }

            [JsonPropertyName("quantity")]
            public int Quantity { get; set; }

            [JsonPropertyName("unit_price")]
            public decimal UnitPrice { get; set; }

            [JsonPropertyName("subtotal")]
            public decimal Subtotal { get; set; }
        
    }
}
