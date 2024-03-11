namespace MG.Net6.API.CleanArchitecture.DemoAPI.Contracts;

public interface IDependencyInjectionService
{
    void Register(IServiceCollection services, IConfiguration configuration);
}
