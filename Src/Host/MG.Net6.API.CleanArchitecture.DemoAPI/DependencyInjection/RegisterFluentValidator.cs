using FluentValidation;
using FluentValidation.AspNetCore;
using MG.Net6.API.CleanArchitecture.DemoAPI.Contracts;
using System.Reflection;

namespace MG.Net6.API.CleanArchitecture.DemoAPI.DependencyInjection;

public class RegisterFluentValidator : IDependencyInjectionService
{
    public void Register(IServiceCollection services, IConfiguration config)
    {
        services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(Assembly.Load("MG.Net6.API.CleanArchitecture.Application"));
    }
}
