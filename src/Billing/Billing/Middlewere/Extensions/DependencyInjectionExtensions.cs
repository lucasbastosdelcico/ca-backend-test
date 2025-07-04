using Application.Interfaces;
using Application.Services;
using Billing.Application.Interfaces;
using Billing.Application.Interfaces.InfraInterfaces;
using Billing.Application.Services;
using Billing.Domain.Interfaces;
using Billing.Infrastructure.ExternalBilling;
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
            services.AddScoped<IBillingRepository, BillingRepository>();


            // Services
            services.AddScoped<ICustomerServices, CustomerServices>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<IExternalBillingService, ExternalBillingService>();
            services.AddScoped<IExternalBillingClient, ExternalBilling>();
            return services;
        }
    }
}
