using Billing.Domain.Entities.Base;

namespace Billing.Domain.Entities
{
    public class Customer : EntityBase
    {
        public string? Name { get; set; } 
        public string? Email { get; set; }
        public string? Address { get; set; }

    }
}
