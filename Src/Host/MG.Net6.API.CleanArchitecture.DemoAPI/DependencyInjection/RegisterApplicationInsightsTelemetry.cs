using MG.Net6.API.CleanArchitecture.DemoAPI.Contracts;

namespace MG.Net6.API.CleanArchitecture.DemoAPI.DependencyInjection;

public class RegisterApplicationInsightsTelemetry : IDependencyInjectionService
{
    public void Register(IServiceCollection services, IConfiguration config)
    {
    }
}
