using MediatR;
using MG.Net6.API.CleanArchitecture.DemoAPI.Contracts;
using MG.Net6.API.CleanArchitecture.DemoAPI.Infrastructure.Behaviours;
using System.Reflection;

namespace MG.Net6.API.CleanArchitecture.DemoAPI.DependencyInjection;
 

public class RegisterMediatR : IDependencyInjectionService
{
    public void Register(IServiceCollection services, IConfiguration config)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.Load("MG.Net6.API.CleanArchitecture.Application"));
        });
        // Register MediatR pipeline behaviors, in the same order the behaviors should be called.
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
    }
}