using Application.DTO.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICustomerServices
    {
        Task<IEnumerable<CustomerCommand>> GetAllAsync();
        Task<CustomerCommand> GetByIdAsync(int id);
        Task AddAsync(CustomerCommand customer);
        Task UpdateAsync(CustomerCommand customer);
        Task DeleteAsync(int id);

    }
}
