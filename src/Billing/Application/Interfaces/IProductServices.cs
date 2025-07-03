using Application.DTO.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductCommand>> GetAllAsync();
        Task<ProductCommand> GetByIdAsync(int id);
        Task AddAsync(ProductCommand product);
        Task UpdateAsync(ProductCommand product);
        Task DeleteAsync(int id);
    }
}
