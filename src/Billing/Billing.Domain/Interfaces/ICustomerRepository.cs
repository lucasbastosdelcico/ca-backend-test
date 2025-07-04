namespace Billing.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Entities.Customer>> GetAllAsync();
        Task<Entities.Customer> GetByIdAsync(Guid id);
        Task AddAsync(Entities.Customer customer);
        Task UpdateAsync(Entities.Customer customer);
        Task DeleteAsync(Guid id);
    }
}
