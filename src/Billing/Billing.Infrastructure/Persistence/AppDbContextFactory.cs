using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Billing.Infrastructure.Persistence
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

           
            var connectionString = "Server=localhost;DataBase=BillingDB;Uid=root;Pwd=r9souronaldo;Port=3306;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
