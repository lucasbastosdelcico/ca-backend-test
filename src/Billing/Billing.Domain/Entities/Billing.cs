using Billing.Domain.Entities.Base;

namespace Billing.Domain.Entities
{
    public class Billing : EntityBase
    {
        public string? InvoiceNumber { get; set; }
        public Customer? Customer { get; set; }
        public Decimal TotalAmount { get; set; }
        public string? Currency { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<BillingLine>? BillingLines{ get; set; }

    }
}
