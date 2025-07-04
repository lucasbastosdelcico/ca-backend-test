using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Domain.Interfaces
{
    public interface IBillingRepository
    {
        Task AddBillingAsync(Domain.Entities.Billing billing);
    }
}
