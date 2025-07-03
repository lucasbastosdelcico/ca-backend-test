namespace Billing.Domain.Entities.Base
{
    public  class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
