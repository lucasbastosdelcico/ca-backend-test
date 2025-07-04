using Billing.Domain.Entities;
using Billing.Domain.Interfaces;
using Billing.Infrastructure.Persistence;

namespace Billing.Infrastructure.Repositories
{
    public class BillingRepository : IBillingRepository
    {
        private readonly AppDbContext _context;

        public BillingRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddBillingAsync(Domain.Entities.Billing billing) 
        {
             if(billing == null) 
                throw new ArgumentNullException(nameof(billing));

            await _context.AddAsync(billing);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
