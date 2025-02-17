using Microsoft.Extensions.DependencyInjection;
using System.Infra.DBConnection;

namespace System.Application.DependencyInjection;

public class InjectionModule
{
    public static void BindService(ServiceCollection servicos)
    {
        servicos.AddScoped<Connection>();
    }
}
