namespace Billing.Domain.Entities.Base
{
    public  class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
