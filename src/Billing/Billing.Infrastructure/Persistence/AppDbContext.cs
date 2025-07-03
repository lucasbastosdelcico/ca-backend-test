using Billing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Domain.Entities.Billing> Billings { get; set; }
        public DbSet<BillingLine> BillingLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(c => c.Name).IsRequired();
                entity.Property(c => c.Email).IsRequired();
                entity.Property(c => c.Address).IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.NameProduct).IsRequired();
            });
        }
    }
}
