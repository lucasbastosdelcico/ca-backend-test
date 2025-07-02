using Billing.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Domain.Entities
{
    public class Billing : EntityBase
    {
        public string? InvoiceNumber { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();
        public Decimal TotalAmount { get; set; }
        public string Currency { get; set; } = "BRL";
        public IEnumerable<BillingLine> BillingLine { get; set; } = new List<BillingLine>();

    }
}
