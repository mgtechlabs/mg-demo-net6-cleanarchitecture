using MG.Net6.API.CleanArchitecture.DemoAPI.Contracts;
using MG.Net6.API.CleanArchitecture.Domain.Contracts.Repositories;
using MG.Net6.API.CleanArchitecture.Infrastructure.Persistence.MGDemoDb;
using MG.Net6.API.CleanArchitecture.Infrastructure.Persistence.MGDemoDb.Repositories;

namespace MG.Net6.API.CleanArchitecture.DemoAPI.DependencyInjection;

public class RegisterContracts : IDependencyInjectionService
{
    public void Register(IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<IToDoRepository, ToDoRepository>();
        services.AddSingleton<MGDemoDbContext>();
        services.AddHttpContextAccessor();
    }
}
