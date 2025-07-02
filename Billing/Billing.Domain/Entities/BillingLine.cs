using Billing.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Domain.Entities
{
    public class BillingLine : EntityBase
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = new Product();
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }

    }
}
