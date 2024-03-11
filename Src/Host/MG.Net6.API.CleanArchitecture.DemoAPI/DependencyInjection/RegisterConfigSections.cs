using MG.Net6.API.CleanArchitecture.DemoAPI.Contracts;
using MG.Net6.API.CleanArchitecture.Domain.Configurations;

namespace MG.Net6.API.CleanArchitecture.DemoAPI.DependencyInjection;

public class RegisterConfigSections : IDependencyInjectionService
{
    public void Register(IServiceCollection services, IConfiguration config)
    {
        services.Configure<SystemParameterConfiguration>(config.GetSection(ApplicationConfig.SYSTEM_PARAMETER_SECTION));
    }
}
