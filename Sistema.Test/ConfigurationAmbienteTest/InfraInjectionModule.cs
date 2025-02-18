using Microsoft.Extensions.DependencyInjection;
using System.Domain.Validations;
using System.Infra.Repositories;
using System.Domain.Interfaces;
using System.Domain.Entities;
using System.Infra.Services;

namespace System.Test.InfraInjectionModule;

public static class InfraInjectionModule
{
    public static void BindService(ServiceCollection services)
    {
        services.AddScoped<IRepository<Customer>, CustomerRepository>();
        services.AddScoped<IRepository<Invoice>, InvoiceRepository>();
        services.AddScoped<CustomerValidation>();
        services.AddScoped<InvoiceValidation>();
        services.AddScoped<CustomerService>();
        services.AddScoped<InvoiceService>();
    }
}
