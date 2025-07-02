using Application.Interfaces;
using Application.Services;
using Billing.Domain.Interfaces;
using Billing.Infrastructure.Repositories;

namespace Billing.Middlewere.Extensions
{
    public  static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // Services
            services.AddScoped<ICustomerServices, CustomerServices>();
            services.AddScoped<IProductServices, ProductServices>();

            return services;
        }
    }
}
