using Application.DTO.Command;
using Application.Interfaces;
using AutoMapper;
using Billing.Domain.Entities;
using Billing.Domain.Interfaces;

namespace Application.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerServices(
            ICustomerRepository customerRepository,
            IMapper mapper
            )
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CustomerCommand>> GetAllAsync()
        {
            var result = await _customerRepository.GetAllAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<CustomerCommand>>(result);

        }
        public async Task<CustomerCommand> GetByIdAsync(Guid id)
        {
            var result = await _customerRepository.GetByIdAsync(id).ConfigureAwait(false);
            return _mapper.Map<CustomerCommand>(result);
        }
        public async Task AddAsync(CustomerCommand customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            var newCustomer = _mapper.Map<Customer>(customer);
            await _customerRepository.AddAsync(newCustomer).ConfigureAwait(false);
        }
        public async Task UpdateAsync(CustomerCommand customer)
        {
            var newCustomer = _mapper.Map<Customer>(customer);
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            await _customerRepository.UpdateAsync(newCustomer).ConfigureAwait(false);
        }
        public async Task DeleteAsync(Guid id)
        {
            if (id.Equals(0)) throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            await _customerRepository.DeleteAsync(id).ConfigureAwait(false);
        }
    }
}
