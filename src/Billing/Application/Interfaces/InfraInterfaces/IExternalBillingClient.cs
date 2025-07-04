using Billing.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Application.Interfaces.InfraInterfaces
{
    public interface IExternalBillingClient
    {
        Task<IEnumerable<BillingDTO>> GetBillingsAsync();
        Task<BillingDTO> GetBillingsByIdAsync(int id);
    }
}
