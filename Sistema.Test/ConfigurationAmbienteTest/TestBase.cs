using Microsoft.Extensions.DependencyInjection;

namespace System.Test.ConfigurationAmbienteTest;

public abstract class TestBase : IDisposable
{
    protected ServiceProvider ServiceProvider;

    protected TestBase()
    {
        ServiceProvider = GetServiceCollection().BuildServiceProvider();
    }

    private IServiceCollection GetServiceCollection()
    {
        var services = new ServiceCollection();
        InfraInjectionModule.InfraInjectionModule.BindService(services);
        return services;
    }

    public virtual void Dispose()
    {
        ServiceProvider.Dispose();
    }
}
