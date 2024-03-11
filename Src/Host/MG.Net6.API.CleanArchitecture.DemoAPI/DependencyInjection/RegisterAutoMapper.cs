using MG.Net6.API.CleanArchitecture.DemoAPI.Contracts;
using System.Reflection;

namespace MG.Net6.API.CleanArchitecture.DemoAPI.DependencyInjection;

public class RegisterAutoMapper : IDependencyInjectionService
{
    public void Register(IServiceCollection services, IConfiguration config)
    {
        services.AddAutoMapper(Assembly.Load("MG.Net6.API.CleanArchitecture.Application"));
    }
}
